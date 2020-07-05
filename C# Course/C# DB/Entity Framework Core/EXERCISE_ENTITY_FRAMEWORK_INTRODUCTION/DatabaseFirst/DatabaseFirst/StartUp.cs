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
                Console.WriteLine(RemoveTown(dbData));
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

        public static string GetDepartmentsWithMoreThan5Employees(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            var departmentData = context.Departments
                .Where(dep => dep.Employees.Count() > 5)
                .OrderBy(dep => dep.Employees.Count())
                .ThenBy(dep => dep.Name)
                .Select(d => new
                {
                    DepName = d.Name,
                    Manager = d.Manager.FirstName + " " + d.Manager.LastName,
                    Employees = d.Employees.Select(e => new
                    {
                        e.FirstName,
                        e.LastName,
                        Position = e.JobTitle
                    }).OrderBy(x => x.FirstName).ThenBy(x => x.LastName).ToList()
                }).ToList();

            foreach (var dep in departmentData)
            {
                sb.AppendLine($"{dep.DepName} - {dep.Manager}");

                foreach (var employee in dep.Employees)
                {
                    sb.AppendLine($"{employee.FirstName + " " + employee.LastName} - {employee.Position}");
                }
            }

            return sb.ToString().TrimEnd();
        }


        public static string GetLatestProjects(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            var projects = context.Projects
                .OrderByDescending(proj => proj.StartDate)
                .Take(10)
                .OrderBy(proj => proj.Name)
                .Select(proj => new
                {
                    proj.Name,
                    proj.Description,
                    StartDate = proj.StartDate.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture)
                }).ToList();

            foreach (var proj in projects)
            {
                sb.AppendLine($"{proj.Name}");
                sb.AppendLine($"{proj.Description}");
                sb.AppendLine($"{proj.StartDate}");
            }

            return sb.ToString().TrimEnd();
        }

        public static string IncreaseSalaries(SoftUniContext context)
        {
            var departmentsList = new String[] { "Engineering", "Tool Design", "Marketing", "Information Services" };
            var emploeyeesToUpgrade = context.Employees
                .Where(e => departmentsList
                .Any(x => x == e.Department.Name))
                .OrderBy(e => e.FirstName)
                .ThenBy(e => e.LastName);

            StringBuilder sb = new StringBuilder();

            foreach (var employee in emploeyeesToUpgrade)
            {
                employee.Salary *= (Decimal)1.12;
                sb.AppendLine($"{employee.FirstName} {employee.LastName} (${employee.Salary:F2})");
            }

            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }


        public static string GetEmployeesByFirstNameStartingWithSa(SoftUniContext context)
        {
            var employees = context.Employees
                .Where(e => e.FirstName.StartsWith("Sa") || e.FirstName.StartsWith("SA"))
                .Select(e => new
                {
                    e.FirstName,
                    e.LastName,
                    e.JobTitle,
                    e.Salary
                })
                .OrderBy(e => e.FirstName)
                .ThenBy(e => e.LastName)
                .ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var employee in employees)
            {
                sb.AppendLine($"{employee.FirstName} {employee.LastName} - {employee.JobTitle} - (${employee.Salary:F2})");              
            }

            return sb.ToString().TrimEnd();
        }

        public static string DeleteProjectById(SoftUniContext context)
        {
            context.EmployeesProjects.RemoveRange(context.EmployeesProjects.Where(x => x.ProjectId == 2).ToList());
            context.Projects.Remove(context.Projects.Find(2));

            context.SaveChanges();

            StringBuilder sb = new StringBuilder();

            var projects = context.Projects.Take(10).ToList();

            foreach (var project in projects)
            {
                sb.AppendLine($"{project.Name}");
            }

            return sb.ToString().TrimEnd();
        }


        public static string RemoveTown(SoftUniContext context)
        {
            var employeesInSeattle = context.Employees.Where(e => e.Address.Town.Name == "Seattle").ToList();

            foreach (var e in employeesInSeattle)
            {
                e.AddressId = null;
            }

            var addressesInSeattle = context.Addresses.Where(addr => addr.Town.Name == "Seattle").ToList();
            var towns = context.Towns.Where(x => x.Name == "Seattle").ToList();
            int count = addressesInSeattle.Count();

            context.Addresses.RemoveRange(addressesInSeattle);
            context.Towns.RemoveRange(towns);
            context.SaveChanges();

            return $"{count} addresses in Seattle were deleted";
        }
    }
}
