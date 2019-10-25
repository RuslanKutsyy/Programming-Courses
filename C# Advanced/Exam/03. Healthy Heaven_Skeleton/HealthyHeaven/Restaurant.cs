using System.Collections.Generic;
using System.Text;

namespace HealthyHeaven
{
    class Restaurant
    {
        private List<Salad> data;
        private string name;

        public List<Salad> Data
        {
            get { return this.data; }
            set { this.data = value; }
        }

        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }

        public Restaurant(string name)
        {
            this.name = name;
            this.data = new List<Salad>();
        }

        public void Add(Salad salad)
        {
            this.data.Add(salad);
        }

        public bool Buy(string name)
        {
            if (this.data.Count > 0)
            {
                for (int i = 0; i < this.data.Count; i++)
                {
                    if (this.data[i].Name == name)
                    {
                        this.data.RemoveAt(i);
                        return true;
                    }
                }
            }

            return false;
        }

        public string GetHealthiestSalad()
        {
            int winIndex = 0;
            int minCalories = int.MaxValue;
            for (int i = 0; i < this.data.Count; i++)
            {
                int cal = this.data[i].GetTotalCalories();

                if (cal < minCalories)
                {
                    minCalories = cal;
                    winIndex = i;
                }
            }

            return this.data[winIndex].Name;
        }

        public string GenerateMenu()
        {
            StringBuilder newSB = new StringBuilder();
            newSB.AppendLine($"{ this.name} have {this.data.Count} salads:");
            for (int i = 0; i < this.data.Count; i++)
            {
                newSB.AppendLine(this.data[i].ToString());
            }

            return newSB.ToString().Trim();
        }
    }
}
