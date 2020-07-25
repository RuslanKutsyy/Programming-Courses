using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Castle.Core.Internal;
using Newtonsoft.Json;
using ProductShop.Data;
using ProductShop.Models;
using ProductShop.Views;

namespace ProductShop
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var dbContext = new ProductShopContext();

            Console.WriteLine(GetCategoriesByProductsCount(dbContext));
        }

        public static string ImportUsers(ProductShopContext context, string inputJson)
        {
            var jsonData = JsonConvert.DeserializeObject<List<User>>(inputJson);

            context.Users.AddRange(jsonData);
            context.SaveChanges();

            return $"Successfully imported {jsonData.Count}";
        }

        public static string ImportProducts(ProductShopContext context, string inputJson)
        {
            var jsonData = JsonConvert.DeserializeObject<List<Product>>(inputJson);

            context.Products.AddRange(jsonData);
            context.SaveChanges();

            return $"Successfully imported {jsonData.Count}";
        }

        public static string ImportCategories(ProductShopContext context, string inputJson)
        {
            var jsonData = JsonConvert.DeserializeObject<List<Category>>(inputJson).Where(x => x.Name != null);
            context.Categories.AddRange(jsonData);
            context.SaveChanges();

            return $"Successfully imported {jsonData.Count()}";
        }

        public static string ImportCategoryProducts(ProductShopContext context, string inputJson)
        {
            var jsonData = JsonConvert.DeserializeObject<List<CategoryProduct>>(inputJson);
            context.CategoryProducts.AddRange(jsonData);
            var count = context.SaveChanges();

            return $"Successfully imported {count}";
        }

        public static string GetProductsInRange(ProductShopContext context)
        {
            return JsonConvert.SerializeObject(context.Products.Where(x => x.Price >= 500 && x.Price <= 1000)
                .Select(x => new FilteredProductView
                { 
                    name = x.Name,
                    price = (double)x.Price,
                    seller = $"{x.Seller.FirstName} {x.Seller.LastName}"
                })
                .OrderBy(x => x.price)
                .ToList(), Formatting.Indented);
        }

        public static string GetSoldProducts(ProductShopContext context)
        {
            return JsonConvert.SerializeObject(context.Users.Where(x => x.ProductsSold.Any(y => y.Buyer != null))
                .OrderBy(x => x.LastName).ThenBy(x => x.FirstName)
                .Select(x => new UsersWithBuyersView
                {
                    firstName = x.FirstName,
                    lastName = x.LastName,
                    soldProducts = x.ProductsSold
                    .Where(p => p.Buyer != null)
                    .Select(p => new SoldProductView
                    {
                        name = p.Name,
                        price = (double)p.Price,
                        buyerFirstName = p.Buyer.FirstName,
                        buyerLastName = p.Buyer.LastName
                    }).ToList()
                })
                .ToList(), Formatting.Indented);
        }

        public static string GetCategoriesByProductsCount(ProductShopContext context)
        {
            var exportCategories = context.Categories
                .OrderByDescending(c => c.CategoryProducts.Count())
                .Select(c => new CategoryExportView
                {
                    category = c.Name,
                    productsCount = c.CategoryProducts.Count(),
                    averagePrice = $@"{c.CategoryProducts
                    .Sum(p => p.Product.Price) / c.CategoryProducts.Count():F2}",
                    totalRevenue = $"{c.CategoryProducts.Sum(p => p.Product.Price):F2}"
                })
                .ToList();

            var json = JsonConvert.SerializeObject(exportCategories, Formatting.Indented);

            return json;
        }
    }
}