package Classes;

public class Vehicle {
    private double DEFAULT_FUEL_CONSUMPTION;
    private double fuelConsumption;
    private double fuel;
    private int horsePower;

    public Vehicle(double fuel, int horsePower){
        this.fuel = fuel;
        this.horsePower = horsePower;
        this.setDEFAULT_FUEL_CONSUMPTION(1.25);
    }

    public double getFuel() {
        return this.fuel;
    }

    public void setFuel(double fuel) {
        this.fuel = fuel;
    }

    public double getFuelConsumption() {
        return this.fuelConsumption;
    }

    protected void setDEFAULT_FUEL_CONSUMPTION(double default_fuel_consumption){
        this.DEFAULT_FUEL_CONSUMPTION = default_fuel_consumption;
    }

    public void setFuelConsumption(double fuelConsumption) {
        this.fuelConsumption = fuelConsumption;
    }

    public int getHorsePower() {
        return this.horsePower;
    }

    public void setHorsePower(int horsePower) {
        this.horsePower = horsePower;
    }

    public void drive(double kilometers){
        this.fuel -= kilometers * this.getFuelConsumption();
    }
}
