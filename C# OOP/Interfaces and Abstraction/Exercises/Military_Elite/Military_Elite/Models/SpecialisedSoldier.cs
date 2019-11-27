using System;
using System.Collections.Generic;
using System.Text;

namespace Military_Elite
{
    public class SpecialisedSoldier : ISpecialisedSoldier
    {
        private string corps;

        public string Corps
        {
            get => this.corps;
            set
            {
                if (value == "Airforces" || value == "Marines")
                {
                    this.corps = value;
                }
            }
        }
        public string ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public decimal Salary { get; set; }
    }
}
