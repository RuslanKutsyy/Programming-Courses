using SoftUni.Data;
using SoftUni.Models;
using System;
using System.Linq;
using System.Text;

namespace SoftUni
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            SoftUniContext dbContext = new SoftUniContext();
            Console.WriteLine(AddNewAddressToEmployee(dbContext));
        }

        public static string AddNewAddressToEmployee(SoftUniContext context)
        {
            var address = new Address();
            address.AddressText = "Vitoshka 15";
            address.TownId = 4; ;
            context.Addresses.Add(address);

            var worker = context.Employees.Where(x => x.LastName.Equals("Nakov")).FirstOrDefault();
            worker.Address = address;
            address.Employees.Add(worker);
            context.SaveChanges();

            var sb = new StringBuilder();

            context.Employees.OrderByDescending(x => x.AddressId).Take(10).Select(x => sb.AppendLine($"{x.Address.AddressText}")).ToList();

            return sb.ToString().TrimEnd();
        }
    }
}