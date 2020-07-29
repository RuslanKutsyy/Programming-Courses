using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AutoMapper;
using CarDealer.Data;
using CarDealer.DTO;
using CarDealer.Models;
using Newtonsoft.Json;

namespace CarDealer
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var context = new CarDealerContext();
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            var cars = File.ReadAllText(@"C:\\Users\rusla\\Documents\\GitHub\\SoftUniCourses\\C# Course\\C# DB\\Entity Framework Core\\JSON PROCESSING\\Car Dealer\\CarDealer\\Datasets\\cars.json");
            var customers = File.ReadAllText(@"C:\\Users\rusla\\Documents\\GitHub\\SoftUniCourses\\C# Course\\C# DB\\Entity Framework Core\\JSON PROCESSING\\Car Dealer\\CarDealer\\Datasets\\customers.json");
            var parts = File.ReadAllText(@"C:\\Users\rusla\\Documents\\GitHub\\SoftUniCourses\\C# Course\\C# DB\\Entity Framework Core\\JSON PROCESSING\\Car Dealer\\CarDealer\\Datasets\\parts.json");
            var sales = File.ReadAllText(@"C:\\Users\rusla\\Documents\\GitHub\\SoftUniCourses\\C# Course\\C# DB\\Entity Framework Core\\JSON PROCESSING\\Car Dealer\\CarDealer\\Datasets\\sales.json");
            var suppliers = File.ReadAllText(@"C:\\Users\rusla\\Documents\\GitHub\\SoftUniCourses\\C# Course\\C# DB\\Entity Framework Core\\JSON PROCESSING\\Car Dealer\\CarDealer\\Datasets\\suppliers.json");

            ImportSuppliers(context, suppliers);
            ImportParts(context, parts);
            ImportCars(context, cars);
            ImportCustomers(context, customers);
            ImportSales(context, sales);
        }

        public static string ImportSuppliers(CarDealerContext context, string inputJson)
        {
            var suppliers = JsonConvert.DeserializeObject<List<Supplier>>(inputJson);
            context.Suppliers.AddRange(suppliers);
            context.SaveChanges();

            return $"Successfully imported {suppliers.Count()}.";
        }
        public static string ImportParts(CarDealerContext context, string inputJson)
        {
            var parts = JsonConvert.DeserializeObject<List<Part>>(inputJson)
                .Where(p => context.Suppliers.Any(x => x.Id == p.SupplierId));
            context.Parts.AddRange(parts);
            var count = context.SaveChanges();

            return $"Successfully imported {count}.";
        }

        public static string ImportCars(CarDealerContext context, string inputJson)
        {
            var cars = JsonConvert.DeserializeObject<List<CarsImportDTO>>(inputJson);

            foreach (var carDTO in cars)
            {
                var car = new Car
                {
                    Make = carDTO.Make,
                    Model = carDTO.Model,
                    TravelledDistance = carDTO.TravelledDistance
                };

                context.Cars.Add(car);

                foreach (var partID in carDTO.PartsId)
                {
                    var partCar = new PartCar
                    {
                        CarId = car.Id,
                        PartId = partID
                    };

                    if (car.PartCars.FirstOrDefault(p => p.PartId == partID) == null)
                    {
                        context.PartCars.Add(partCar);
                    }
                }
            }

            context.SaveChanges();

            return $"Successfully imported {cars.Count()}.";
        }

        public static string ImportCustomers(CarDealerContext context, string inputJson)
        {
            var customers = JsonConvert.DeserializeObject<List<Customer>>(inputJson);
            context.Customers.AddRange(customers);
            var count = context.SaveChanges();

            return $"Successfully imported {count}.";
        }

        public static string ImportSales(CarDealerContext context, string inputJson)
        {
            var sales = JsonConvert.DeserializeObject<List<Sale>>(inputJson);
            context.Sales.AddRange(sales);
            var count = context.SaveChanges();

            return $"Successfully imported {count}.";
        }
    }
}