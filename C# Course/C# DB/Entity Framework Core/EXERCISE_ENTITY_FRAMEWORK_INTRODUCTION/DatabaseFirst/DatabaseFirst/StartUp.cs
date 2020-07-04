using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Primitives;
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
            var dbData = new SoftUniContext();
            Console.WriteLine(GetEmployeesFullInformation(dbData));
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
    }
}
