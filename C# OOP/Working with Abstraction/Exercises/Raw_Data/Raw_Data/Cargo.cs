namespace Raw_Data
{
    public class Cargo
    {
        private int CargoWeight { get; set; }
        private string cargoType;

        public string CargoType
        {
            get { return this.cargoType; }
            set { this.cargoType = value; }
        }

        public Cargo(int cargoWeight, string cargoType)
        {
            this.CargoWeight = cargoWeight;
            this.cargoType = cargoType;
        }
    }
}
