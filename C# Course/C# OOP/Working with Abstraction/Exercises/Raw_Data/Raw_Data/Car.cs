using System;
using System.Collections.Generic;
using System.Text;

namespace Raw_Data
{
    class Car
    {
        private Tire[] tires;
        public string Model { get; set; }
        private Engine engine;
        private Cargo cargo;

        public Tire[] Tires
        {
            get { return this.tires; }
            set { this.tires = value; }
        }

        public Engine Engine
        {
            get { return this.engine; }
            set { this.engine = value; }
        }

        public Cargo Cargo
        {
            get { return this.cargo; }
            set { this.cargo = value; }
        }

        public Car(string model, int engineSpeed, int enginePower, int cargoWeight, string cargoType, double tire1Pressure, int tire1Age, double tire2Pressure, int tire2Age, double tire3Pressure, int tire3Age,
                double tire4Pressure, int tire4Age)
        {
            this.Model = model;
            this.engine = new Engine(engineSpeed, enginePower);
            this.tires = new Tire[]
            {
                new Tire(tire1Pressure, tire1Age),
                new Tire(tire2Pressure, tire2Age),
                new Tire(tire3Pressure, tire3Age),
                new Tire(tire4Pressure, tire4Age),
            };

            this.cargo = new Cargo(cargoWeight, cargoType);
        }
    }
}
