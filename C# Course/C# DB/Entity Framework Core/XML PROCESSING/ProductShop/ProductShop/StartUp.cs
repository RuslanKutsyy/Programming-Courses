using ProductShop.Data;
using ProductShop.Dtos.Import;
using ProductShop.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml;

namespace ProductShop
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var usersXml = File.ReadAllText("../../../Datasets/users.xml");
            var productsXml = File.ReadAllText("../../../Datasets/products.xml");
            var context = new ProductShopContext();
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            Console.WriteLine(ImportUsers(context, usersXml));
            Console.WriteLine(ImportProducts(context, productsXml));

        }

        public static string ImportUsers(ProductShopContext context, string inputXml)
        {
            const string rootElement = "Users";
            var usersResult = XmlConverter.Deserializer<ImportUserDto>(inputXml, rootElement);

            List<User> users = new List<User>();

            foreach (var importUserDto in usersResult)
            {
                var user = new User
                {
                    FirstName = importUserDto.FirstName,
                    LastName = importUserDto.LastName,
                    Age = importUserDto.Age
                };
                users.Add(user);
            }

            context.Users.AddRange(users);
            context.SaveChanges();

            return $"Successfully imported {users.Count}";
        }

        public static string ImportProducts(ProductShopContext context, string inputXml)
        {
            const string rootElement = "Products";
            var productsDtos = XmlConverter.Deserializer<ImportProductDto>(inputXml, rootElement);

            var products = productsDtos.Select(x => new Product
            {
                Name = x.Name,
                Price = x.Price,
                SellerId = x.SellerId,
                BuyerId = x.BuyerId
            }).ToArray();

            context.Products.AddRange(products);
            context.SaveChanges();


            return $"Successfully imported {products.Length}";
        }
    }
}