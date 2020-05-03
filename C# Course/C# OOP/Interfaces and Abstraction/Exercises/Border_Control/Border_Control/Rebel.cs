using System;
using System.Collections.Generic;
using System.Text;

namespace Border_Control
{
    public class Rebel : IBuyer
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Group { get; set; }
        public int Food { get; set; }
        public string BirthdayDate { get ; set; }

        public Rebel(string name, int age, string group)
        {
            this.Name = name;
            this.Age = age;
            this.Group = group;
            this.Food = 0;
        }

        public int BuyFood()
        {
            this.Food += 5;
            return 5;
        }
    }
}
