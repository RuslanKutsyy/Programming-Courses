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

            Console.WriteLine(GetProductsInRange(dbContext));
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
    }
}