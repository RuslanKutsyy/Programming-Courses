using System;
using System.Collections.Generic;
using System.Text;

namespace HealthyHeaven
{
    class Vegetable
    {
        private string name;
        private int calories;

        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }

        public int Calories
        {
            get { return this.calories; }
            set { this.calories = value; }
        }

        public Vegetable(string name, int calories)
        {
            this.name = name;
            this.calories = calories;
        }

        public override string ToString()
        {
            return $" - {this.name} have {this.calories} calories";

        }
    }
}
