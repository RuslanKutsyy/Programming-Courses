using System;
using System.Collections.Generic;
using System.Text;

namespace Military_Elite
{
    public class Private : IPrivate
    {
        public decimal Salary { get; set; }
        public string ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public Private(string id, string firstName, string lastName, decimal salary)
        {
            this.ID = id;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Salary = salary;
        }
    }
}
