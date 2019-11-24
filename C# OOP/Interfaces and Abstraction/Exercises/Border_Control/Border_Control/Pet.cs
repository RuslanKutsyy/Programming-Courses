using System;
using System.Collections.Generic;
using System.Text;

namespace Border_Control
{
    public class Pet : IMammal
    {
        public string Name { get; set; }
        public string BirthdayDate { get; set; }

        public Pet(string name, string birthdayDate)
        {
            this.Name = name;
            this.BirthdayDate = birthdayDate;
        }
    }
}
