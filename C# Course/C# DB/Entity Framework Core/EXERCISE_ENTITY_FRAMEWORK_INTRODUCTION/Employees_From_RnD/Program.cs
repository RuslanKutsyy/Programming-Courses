using System;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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
            Console.WriteLine(GetEmployeesFromResearchAndDevelopment(dbContext));
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
