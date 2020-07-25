using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Castle.Core.Internal;
using Newtonsoft.Json;
using ProductShop.Data;
using ProductShop.Models;

namespace ProductShop
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var dbContext = new ProductShopContext();
            Console.WriteLine(ImportCategories(dbContext, File.ReadAllText(@"C:\\Users\rusla\\Documents\\GitHub\\SoftUniCourses\\C# Course\\C# DB\\Entity Framework Core\\JSON PROCESSING\\Product Shop\\ProductShop\\Datasets\\categories.json")));
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

        //public static string ImportCategoryProducts(ProductShopContext context, string inputJson)
        //{
        //    var jsonData = JsonConvert.DeserializeObject<List<CategoryProduct>>(inputJson);
        //    context.CategoryProducts.AddRange(jsonData);
        //    context.SaveChanges();

        //    return $"Successfully imported {jsonData.Count}";
        //}
    }
}