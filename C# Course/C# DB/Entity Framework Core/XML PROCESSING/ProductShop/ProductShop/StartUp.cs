using ProductShop.Data;
using ProductShop.Dtos.Export;
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
            //var usersXml = File.ReadAllText("../../../Datasets/users.xml");
            //var productsXml = File.ReadAllText("../../../Datasets/products.xml");
            //var categoriesXml = File.ReadAllText("../../../Datasets/categories.xml");
            //var categoryProductsXml = File.ReadAllText("../../../Datasets/categories-products.xml");
            var context = new ProductShopContext();
            //context.Database.EnsureDeleted();
            //context.Database.EnsureCreated();

            //Console.WriteLine(ImportUsers(context, usersXml));
            //Console.WriteLine(ImportProducts(context, productsXml));
            //Console.WriteLine(ImportCategories(context, categoriesXml));
            //Console.WriteLine(ImportCategoryProducts(context, categoryProductsXml));

            //var productsInRange = GetProductsInRange(context);
            //File.WriteAllText("../../../Results/productsInRange.xml", productsInRange);

            //var soldProducts = GetSoldProducts(context);
            //File.WriteAllText("../../../Results/soldProducts.xml", soldProducts);

            //var categories = GetCategoriesByProductsCount(context);
            //File.WriteAllText("../../../Results/cateforiesByProductsCount.xml", categories);

            var usersWithProducts = GetUsersWithProducts(context);
            File.WriteAllText("../../../Results/usersWithProducts.xml", usersWithProducts);
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

        public static string ImportCategories(ProductShopContext context, string inputXml)
        {
            const string rootElement = "Categories";
            var categoriesDto = XmlConverter.Deserializer<ImportCategoryDto>(inputXml, rootElement);

            var categories = categoriesDto.Select(x => new Category
            {
                Name = x.Name
            }).ToArray();

            context.Categories.AddRange(categories);
            context.SaveChanges();

            return $"Successfully imported {categories.Length}";
        }

        public static string ImportCategoryProducts(ProductShopContext context, string inputXml)
        {
            const string rootElement = "CategoryProducts";

            var categoriesProductsResult = XmlConverter.Deserializer<ImportCategoryProductDto>(inputXml, rootElement);

            var categoriesCount = context.Categories.Count();
            var productsCount = context.Products.Count();

            var categoriesProducts = categoriesProductsResult
                .Where(x => x.CategoryId <= categoriesCount && x.ProductId <= productsCount)
                .Select(x => new CategoryProduct { CategoryId = x.CategoryId, ProductId = x.ProductId })
                .ToArray();
            context.AddRange(categoriesProducts);
            context.SaveChanges();

            return $"Successfully imported {categoriesProducts.Length}";
        }

        public static string GetProductsInRange(ProductShopContext context)
        {
            const string rootElement = "Products";
            var products = context.Products.Where(p => p.Price >= 500 && p.Price <= 1000)
                .Select(x => new ExportProductInfoDto
                {
                    Name = x.Name,
                    Price = x.Price,
                    Buyer = x.Buyer.FirstName + " " + x.Buyer.LastName

                })
                .OrderBy(x => x.Price)
                .Take(10).ToList();

            return XmlConverter.Serialize(products, rootElement);
        }

        public static string GetSoldProducts(ProductShopContext context)
        {
            const string rootElement = "Users";
            var usersWithSoldProducts = context.Users
                .Where(u => u.ProductsSold.Count > 0)
                .OrderBy(u => u.LastName)
                .ThenBy(u => u.FirstName)
                .Take(5)
                .Select(u => new ExportUserInfoDto
                {
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    SoldProducts = u.ProductsSold.Select(ps => new ExportUserProductInfoDto
                    {
                        Name = ps.Name,
                        Price = ps.Price
                    }).ToList()
                }).ToList();

            return XmlConverter.Serialize(usersWithSoldProducts, rootElement);
        }

        public static string GetCategoriesByProductsCount(ProductShopContext context)
        {
            const string rootElement = "Categories";

            var categories = context.Categories
                .Select(c => new ExportCategoryInfoDto
                {
                    Name = c.Name,
                    Count = c.CategoryProducts.Count,
                    AveragePrice = c.CategoryProducts.Average(x => x.Product.Price),
                    TotalRevenue = c.CategoryProducts.Sum(x => x.Product.Price)
                })
                .OrderByDescending(c => c.Count)
                .ThenBy(c => c.TotalRevenue)
                .ToList();

            return XmlConverter.Serialize(categories, rootElement);
        }

        public static string GetUsersWithProducts(ProductShopContext context)
        {
            const string rootElement = "Users";
            var allUsers = context.Users
                .Where(u => u.ProductsSold.Any())
                .OrderByDescending(u => u.ProductsSold.Count())
                .Select(u => new ExportUserWithProductsDto
                {
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    Age = u.Age,
                    SoldProducts = new ExportSoldProductsInfoDto
                    {
                        Count = u.ProductsSold.Count(),
                        Products = u.ProductsSold.Select(p => new ExportUserProductInfoDto
                        {
                            Name = p.Name,
                            Price = p.Price
                        }).OrderByDescending(x => x.Price)
                        .ToList()
                    }
                }).Take(10).ToList();

            var result = new ExportGeneralUserInfoDto
            {
                Count = context.Users.Count(x => x.ProductsSold.Any()),
                Users = allUsers
            };

            return XmlConverter.Serialize(result, rootElement);
        }
    }
}