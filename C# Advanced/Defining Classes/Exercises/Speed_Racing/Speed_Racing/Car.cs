using System;
using System.Collections.Generic;
using System.Text;

namespace Speed_Racing
{
    class Car
    {
        private string model { get; set; }
        private double fuelAmount { get; set; }
        private double fuelConsumptionPerKilometer { get; set; }
        private double travelledDistance { get; set; }

        public string Model
        {
            get { return this.model; }
            set { this.model = value; }
        }

        public double FuelAmount
        {
            get { return this.fuelAmount; }
            set { this.fuelAmount = value; }
        }

        public double FuelConsumptionPerKilometer
        {
            get { return this.fuelConsumptionPerKilometer; }
            set { this.fuelConsumptionPerKilometer = value; }
        }

        public double TravelledDistance
        {
            get { return this.travelledDistance; }
            set { this.travelledDistance = value; }
        }

        public Car(string model, double fuelAmount, double fuelConsumptionFor1km, double travelledDistance)
        {
            this.model = model;
            this.fuelAmount = fuelAmount;
            this.fuelConsumptionPerKilometer = fuelConsumptionFor1km;
        }

        public static void Drive(double carModel, double amountOfKm)
        {

        }
    }
}
