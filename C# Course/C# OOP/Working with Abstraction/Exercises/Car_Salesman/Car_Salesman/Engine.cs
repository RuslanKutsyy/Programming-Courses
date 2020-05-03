namespace Car_Salesman
{
    class Engine
    {
        private string model;
        private int power;
        private int displacement;
        private string efficiency;

        public string Model
        {
            get { return this.model; }
            set { this.model = value; }
        }

        public int Power
        {
            get { return this.power; }
            set { this.power = value; }
        }

        public int Displacement
        {
            get { return this.displacement; }
            set { this.displacement = value; }
        }

        public string Efficiency
        {
            get { return this.efficiency; }
            set { this.efficiency = value; }
        }

        public Engine(string model, int power) : this(model, power, 0, null)
        {
            this.model = model;
            this.power = power;
        }

        public Engine(string model, int power, int displacement) : this(model, power, displacement, null)
        {
            this.model = model;
            this.power = power;
            this.displacement = displacement;
        }

        public Engine(string model, int power, int displacement, string efficiency)
        {
            this.model = model;
            this.power = power;
            this.displacement = displacement;
            this.efficiency = efficiency;
        }
    }
}
