using System.Text;

namespace Car_Salesman
{
    class Car
    {
        private string model;
        private Engine engine;
        private double weight;
        private string color;

        public string Model
        {
            get { return this.model; }
            set { this.model = value; }
        }

        public Engine Engine
        {
            get { return this.engine; }
            set { this.engine = value; }
        }

        public double Weight
        {
            get { return this.weight; }
            set { this.weight = value; }
        }

        public string Color
        {
            get { return this.color; }
            set { this.color = value; }
        }


        public Car() : this(null, null, 0 , null)
        {
        }

        public Car(string model, Engine engine) : this(model, engine, 0, null)
        {
            this.model = model;
            this.engine = engine;
        }

        public Car(string model, Engine engine, double weight) : this(model, engine, weight, null)
        {
            this.model = model;
            this.engine = engine;
            this.weight = weight;
        }
        public Car(string model, Engine engine, string color) : this(model, engine, 0, color)
        {
            this.model = model;
            this.engine = engine;
            this.color = color;
        }

        public Car(string model, Engine engine, double weight, string color)
        {
            this.model = model;
            this.engine = engine;
            this.weight = weight;
            this.color = color;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder($"{this.model}:\n");
            sb.AppendLine($"  {this.Engine.Model}:");
            sb.AppendLine($"    Power: {this.Engine.Power}");
            if (this.Engine.Displacement == 0)
            {
                sb.AppendLine($"    Displacement: n/a");
            }
            else
            {
                sb.AppendLine($"    Displacement: {this.Engine.Displacement}");
            }

            if (this.Engine.Efficiency == null)
            {
                sb.AppendLine($"    Efficiency: n/a");
            }
            else
            {
                sb.AppendLine($"    Efficiency: {this.Engine.Efficiency}");
            }

            if (this.weight == 0)
            {
                sb.AppendLine($"  Weight: n/a");
            }
            else
            {
                sb.AppendLine($"  Weight: {this.weight}");
            }

            if (this.color == null)
            {
                sb.Append($"  Color: n/a");
            }
            else
            {
                sb.Append($"  Color: {this.color}");
            }

            return sb.ToString();
        }
    }
}
