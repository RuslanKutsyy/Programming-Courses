using System;
using System.Collections.Generic;
using System.Text;

namespace Military_Elite
{
    public class LieutenantGeneral : ILieutenantGeneral
    {
        public List<Private> Privates { get; set; }
        public decimal Salary { get; set; }
        public string ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public LieutenantGeneral(string id, string firstName, string lastName, decimal salary)
        {
            this.ID = id;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Salary = salary;
            this.Privates = new List<Private>();
        }

        public override string ToString()
        {

        //Name: Joro Jorev Id: 3 Salary: 100.00
        //Privates:
        //Name: Toncho Tonchev Id: 222 Salary: 80.08
        //Name: Pesho Peshev Id: 1 Salary: 22.22

            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Name: {this.FirstName} {this.LastName} Id: {this.ID} Salary: {this.Salary:F2}");
            sb.AppendLine("Privates:");

            foreach (var privateSoldier in this.Privates)
            {
                sb.AppendLine("  " + privateSoldier.ToString());
            }

            return sb.ToString().Trim();
        }
    }
}
