namespace NeedForSpeed
{
    class Vehicle
    {
        private double defaultFuelConsumption = 1.25;
        private double fuelConsumption;
        private double fuel;
        private int horsePower;

        public Vehicle(int horsePower, double fuel)
        {
            this.HorsePower = horsePower;
            this.Fuel = fuel;
        }

        public double DefaultFuelConsumption
        {
            get { return this.defaultFuelConsumption; }
            set { this.defaultFuelConsumption = value; }
        }
        public double FuelConsumption
        {
            get { return this.fuelConsumption; }
            set { this.fuelConsumption = value; }
        }

        public double Fuel
        {
            get { return this.fuel; }
            set { this.fuel = value; }
        }

        public int HorsePower
        {
            get { return this.horsePower; }
            set { this.horsePower = value; }
        }

        public virtual void Drive(double kilometers)
        {
            this.fuel -= kilometers * DefaultFuelConsumption;
        }

    }
}
