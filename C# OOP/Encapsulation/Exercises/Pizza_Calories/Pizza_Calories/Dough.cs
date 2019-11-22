using System;

namespace Pizza_Calories
{
    public class Dough
    {
        public const int CaloriesPerGramm = 2;
        internal string flour;
        internal string bakingTechnique;
        internal double weight;

        public Dough(string flour, string bakingTechnique, double weight)
        {
            this.Flour = flour;
            this.BakingTechnique = bakingTechnique;
            this.Weight = weight;
        }

        private string Flour
        {
            get { return this.flour; }
            set
            {
                value = ChangeFormat(value);
                if (value != "White" && value != "Wholegrain")
                {
                    throw new Exception("Invalid type of dough.");
                }
                this.flour = value;
            }
        }

        private string BakingTechnique
        {
            get { return this.bakingTechnique; }
            set
            {
                value = ChangeFormat(value);
                if (value[0] != char.ToUpper(value[0]))
                {
                    value = value.Replace(value[0], char.ToUpper(value[0]));
                }

                if (value != "Crispy" && value != "Chewy" && value != "Homemade")
                {
                    throw new Exception("Invalid type of dough.");
                }
                this.bakingTechnique = value;
            }
        }

        private double Weight
        {
            get { return this.weight; }
            set
            {
                if (value < 1 || value > 200)
                {
                    throw new Exception("Dough weight should be in the range [1..200].");
                }
                this.weight = value;
            }
        }

        private double GetModifier(string doughType)
        {
            switch (doughType)
            {
                case "White": return 1.5;
                case "Wholegrain": return 1.0;
                case "Crispy": return 0.9;
                case "Chewy": return 1.1;
                case "Homemade": return 1.0;
                default:
                    return -1;
            }
        }

        public double GetCalories()
        {
            double calories = CaloriesPerGramm * this.Weight * GetModifier(this.Flour) * GetModifier(this.BakingTechnique);

            return calories;
        }

        private string ChangeFormat(string value)
        {
            value = value.ToLower();
            value = value.Replace(value[0], char.ToUpper(value[0]));

            return value;
        }
    }
}
