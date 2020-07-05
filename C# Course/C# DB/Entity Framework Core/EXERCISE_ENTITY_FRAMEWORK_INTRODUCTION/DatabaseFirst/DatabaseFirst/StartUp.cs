using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Primitives;
using SoftUni.Data;
using SoftUni.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace SoftUni
{
    public class StartUp
    {
        static void Main(string[] args)
        {

            using (var dbData = new SoftUniContext())
            {
                Console.WriteLine(GetEmployee147(dbData));
            }        
        }

        public static string GetEmployeesFullInformation(SoftUniContext context)
        {
            var sb = new StringBuilder();
            context.Employees.OrderBy(x => x.EmployeeId)
                .Select(x => sb.AppendLine($"{x.FirstName} {x.LastName} {x.MiddleName} {x.JobTitle} {x.Salary:F2}")).ToArray();

            return sb.ToString().TrimEnd();
        }

        public static string GetEmployeesWithSalaryOver50000(SoftUniContext context)
        {
            var sb = new StringBuilder();
            context.Employees.Where(x => x.Salary > 50000).OrderBy(x => x.FirstName).Select(x => sb.AppendLine($"{x.FirstName} - {x.Salary:F2}")).ToList();
            return sb.ToString().TrimEnd();
        }

        public static string GetEmployeesFromResearchAndDevelopment(SoftUniContext context)
        {
            const string dep = "Research and Development";
            StringBuilder sb = new StringBuilder();
            context.Employees.Where(x => x.Department.Name == dep).OrderBy(x => x.Salary).ThenByDescending(x => x.FirstName)
                .Select(x => sb.AppendLine($"{x.FirstName} {x.LastName} from {x.Department.Name} - ${x.Salary:F2}")).ToList();

            return sb.ToString().TrimEnd();
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

        public static string GetEmployeesInPeriod(SoftUniContext context)
        {
            var employees = context.Employees
                .Where(e => e.EmployeesProjects
                .Any(p => p.Project.StartDate.Year >= 2001 && p.Project.StartDate.Year <= 2003))
                .Select(e => new
                {
                    EmployeeName = e.FirstName + " " + e.LastName,
                    ManagerName = e.Manager.FirstName + " " + e.Manager.LastName,
                    Projects = e.EmployeesProjects
                    .Select(p => new
                    {
                        ProjectName = p.Project.Name,
                        StartDate = p.Project.StartDate,
                        EndDate = p.Project.EndDate
                    })
                    .ToList()
                })
                .Take(10)
                .ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var employee in employees)
            {
                sb.AppendLine($"{employee.EmployeeName} - Manager: {employee.ManagerName}");

                foreach (var project in employee.Projects)
                {
                    var startDate = project.StartDate
                        .ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture);

                    var endDate = project.EndDate == null ?
                        "not finished" :
                        project.EndDate.Value.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture);

                    sb.AppendLine($"--{project.ProjectName} - {startDate} - {endDate}");
                }
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetAddressesByTown(SoftUniContext context){
            StringBuilder sb = new StringBuilder();

            var addresses = context.Addresses.Select(x => new
            {
                AddressText = x.AddressText,
                AddressID = x.AddressId,
                TownName = x.Town.Name,
                EmployeeCount = x.Employees.Count()
            }).OrderByDescending(addr => addr.EmployeeCount)
            .ThenBy(addr => addr.TownName)
            .ThenBy(addr => addr.AddressText)
            .Take(10).ToList();

            foreach (var address in addresses)
            {
                sb.AppendLine($"{address.AddressText}, {address.TownName} - {address.EmployeeCount} employees");
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetEmployee147(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            var employeeData = context.Employees.Where(e => e.EmployeeId == 147).Select(emp => new
            {
                Name = emp.FirstName + " " + emp.LastName,
                EmployeeJobTitle = emp.JobTitle,
                Projects = emp.EmployeesProjects.Select(n => n.Project.Name).OrderBy(x => x).ToList()
            }).FirstOrDefault();

            sb.AppendLine($"{employeeData.Name} - {employeeData.EmployeeJobTitle}");

            foreach (var proj in employeeData.Projects)
            {
                sb.AppendLine($"{proj}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
