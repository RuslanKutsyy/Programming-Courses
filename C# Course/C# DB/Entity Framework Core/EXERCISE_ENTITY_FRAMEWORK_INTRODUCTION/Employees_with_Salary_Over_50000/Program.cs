using System;
using System.Linq;
using System.Text;
using SoftUni.Data;
using SoftUni.Models;

namespace SoftUni
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            SoftUniContext dbContext = new SoftUniContext();
            Console.WriteLine(GetEmployeesWithSalaryOver50000(dbContext));
        }

        public static string GetEmployeesWithSalaryOver50000(SoftUniContext context)
        {
            var sb = new StringBuilder();
            context.Employees.Where(x => x.Salary > 50000).OrderBy(x => x.FirstName).Select(x => sb.AppendLine($"{x.FirstName} - {x.Salary:F2}")).ToList();
            return sb.ToString().TrimEnd();
        }
    }
}
