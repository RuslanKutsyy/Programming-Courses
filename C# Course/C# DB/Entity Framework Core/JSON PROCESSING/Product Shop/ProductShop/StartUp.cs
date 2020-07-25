using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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
            Console.WriteLine(ImportUsers(dbContext, File.ReadAllText(@"C:\\Users\rusla\\Documents\\GitHub\\SoftUniCourses\\C# Course\\C# DB\\Entity Framework Core\\JSON PROCESSING\\Product Shop\\ProductShop\\Datasets\\users.json")));
        }

        public static string ImportUsers(ProductShopContext context, string inputJson)
        {
            var jsonData = JsonConvert.DeserializeObject<List<User>>(inputJson);

            context.AddRange(jsonData);
            context.SaveChanges();

            return $"Successfully imported {jsonData.Count}";
        }
    }
}