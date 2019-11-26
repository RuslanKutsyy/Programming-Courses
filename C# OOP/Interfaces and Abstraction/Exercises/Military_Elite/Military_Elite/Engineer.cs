using System;
using System.Collections.Generic;
using System.Text;

namespace Military_Elite
{
    class Engineer : IEngineer
    {
        public List<Repair> Repairs { get; set; }
        public string Corps { get; set; }
        public string ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public decimal Salary { get; set; }

        public Engineer(string id, string firstName, string lastName, decimal salary, string corps)
        {
            this.ID = id;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Salary = salary;
            this.Corps = corps;
            this.Repairs = new List<Repair>();
        }
    } 
}
