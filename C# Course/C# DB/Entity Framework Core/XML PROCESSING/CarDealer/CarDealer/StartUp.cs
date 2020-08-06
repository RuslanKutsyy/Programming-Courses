using AutoMapper;
using CarDealer.Data;
using System;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using CarDealer.Dtos.Import;
using System.Collections.Generic;
using System.Linq;
using CarDealer.Models;
using Microsoft.EntityFrameworkCore.Internal;

namespace CarDealer
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            CarDealerContext context = new CarDealerContext();
            //context.Database.EnsureDeleted();
            //context.Database.EnsureCreated();

            //var suppliers = File.ReadAllText("../../../Datasets/suppliers.xml");
            //Console.WriteLine(ImportSuppliers(context, suppliers));

            //var parts = File.ReadAllText("../../../Datasets/parts.xml");
            //Console.WriteLine(ImportParts(context, parts));

            //var cars = File.ReadAllText("../../../Datasets/cars.xml");
            //Console.WriteLine(ImportCars(context, cars));
        }

        public static string ImportSuppliers(CarDealerContext context, string inputXml)
        {
            var xmlSerializer = new XmlSerializer(typeof(List<ImportSupplierDto>), new XmlRootAttribute("Suppliers"));
            var suppliersDtos = (List<ImportSupplierDto>)xmlSerializer.Deserialize(new StringReader(inputXml));

            var suppliers = new List<Supplier>();

            foreach (var supplierDto in suppliersDtos)
            {
                var supplier = new Supplier()
                {
                    Name = supplierDto.Name,
                    IsImporter = supplierDto.isImporter
                };
                suppliers.Add(supplier);
            }

            context.Suppliers.AddRange(suppliers);
            context.SaveChanges();

            return $"Successfully imported {suppliers.Count()}";
        }

        public static string ImportParts(CarDealerContext context, string inputXml)
        {
            var xmlSerializer = new XmlSerializer(typeof(List<ImportPartsDto>), new XmlRootAttribute("Parts"));
            var partsDtos = (List<ImportPartsDto>)xmlSerializer.Deserialize(new StringReader(inputXml));

            var parts = new List<Part>();

            foreach (var partDto in partsDtos)
            {
                var supplier = context.Suppliers.FirstOrDefault(x => x.Id == partDto.SupplierId);

                if (supplier == null)
                {
                    continue;
                }

                var part = new Part()
                {
                    Name = partDto.Name,
                    Price = partDto.Price,
                    Quantity = partDto.Quantity,
                    SupplierId = partDto.SupplierId,
                    Supplier = supplier
                };

                parts.Add(part);
            }

            context.Parts.AddRange(parts);
            context.SaveChanges();

            return $"Successfully imported {parts.Count()}";
        }
    }
}