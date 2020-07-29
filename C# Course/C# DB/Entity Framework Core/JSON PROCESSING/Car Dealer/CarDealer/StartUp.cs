using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AutoMapper;
using CarDealer.Data;
using CarDealer.Models;
using Newtonsoft.Json;

namespace CarDealer
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var context = new CarDealerContext();

            var cars = File.ReadAllText(@"C: \\Users\rusla\\Documents\\GitHub\\SoftUniCourses\\C# Course\\C# DB\\Entity Framework Core\\JSON PROCESSING\\Car Dealer\\CarDealer\\Datasets\\cars.json");
            var customers = File.ReadAllText(@"C: \\Users\rusla\\Documents\\GitHub\\SoftUniCourses\\C# Course\\C# DB\\Entity Framework Core\\JSON PROCESSING\\Car Dealer\\CarDealer\\Datasets\\customers.json");
            var parts = File.ReadAllText(@"C: \\Users\rusla\\Documents\\GitHub\\SoftUniCourses\\C# Course\\C# DB\\Entity Framework Core\\JSON PROCESSING\\Car Dealer\\CarDealer\\Datasets\\parts.json");
            var sales = File.ReadAllText(@"C: \\Users\rusla\\Documents\\GitHub\\SoftUniCourses\\C# Course\\C# DB\\Entity Framework Core\\JSON PROCESSING\\Car Dealer\\CarDealer\\Datasets\\sales.json");
            var suppliers = File.ReadAllText(@"C:\\Users\rusla\\Documents\\GitHub\\SoftUniCourses\\C# Course\\C# DB\\Entity Framework Core\\JSON PROCESSING\\Car Dealer\\CarDealer\\Datasets\\suppliers.json");

            ImportSuppliers(context, suppliers);
            //ImportParts(context, parts);
            //ImportCars(context, cars);
            //ImportCustomers(context, customers);
            //ImportSales(context, sales);
        }

        public static string ImportSuppliers(CarDealerContext context, string inputJson)
        {
            var suppliers = JsonConvert.DeserializeObject<List<Supplier>>(inputJson);
            context.Suppliers.AddRange(suppliers);
            context.SaveChanges();

            return $"Successfully imported {suppliers.Count()}.";
        }
    }
}