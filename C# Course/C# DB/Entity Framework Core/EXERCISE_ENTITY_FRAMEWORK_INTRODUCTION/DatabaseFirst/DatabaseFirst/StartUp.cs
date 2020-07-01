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
    }
}
