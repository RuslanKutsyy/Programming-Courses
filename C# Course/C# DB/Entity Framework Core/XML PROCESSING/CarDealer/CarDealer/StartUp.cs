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

namespace CarDealer
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            CarDealerContext context = new CarDealerContext();
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            var suppliers = File.ReadAllText("../../../Datasets/suppliers.xml");
            Console.WriteLine(ImportSuppliers(context, suppliers));
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
    }
}