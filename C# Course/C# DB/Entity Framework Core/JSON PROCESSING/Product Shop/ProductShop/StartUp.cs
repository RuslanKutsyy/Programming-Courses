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

            Console.WriteLine(GetUsersWithProducts(dbContext));
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
                        Name = p.Name,
                        Price = (double)p.Price,
                        BuyerFirstName = p.Buyer.FirstName,
                        BuyerLastName = p.Buyer.LastName
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

        public static string GetUsersWithProducts(ProductShopContext context)
        {
            var allUsers = context.Users
                .Where(x => x.ProductsSold.Any(p => p.Buyer != null))
                .OrderByDescending(x => x.ProductsSold.Count(ps => ps.Buyer != null))
                .Select(x => new UserView
                 {
                     FirstName = x.FirstName,
                     LastName = x.LastName,
                     Age = x.Age,
                     SoldProducts = new AllSoldProductsView
                     {
                         Count = x.ProductsSold.Where(ps => ps.Buyer != null).Count(),
                         Products = x.ProductsSold.Where(ps => ps.Buyer != null)
                        .Select(ps => new ProductView
                        {
                            Name = ps.Name,
                            Price = ps.Price
                        }).ToList()
                     }
                 }).ToList();

            var data = new AllUsersView
            {
                UsersCount = allUsers.Count,
                Users = allUsers
            };

            var json =  JsonConvert.SerializeObject(data, new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore,
                Formatting = Formatting.Indented
            });

            return json;
        }
    }
}