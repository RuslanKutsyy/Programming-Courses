import Classes.Car;
import Classes.RaceMotorcycle;
import Classes.SportCar;

public class Main {

    public static void main(String[] args) {
        Car car = new Car(123.3, 250);
        System.out.println(car.getFuelConsumption());

        RaceMotorcycle raceMotorcycle = new RaceMotorcycle(95.3, 150);
        System.out.println(raceMotorcycle.getFuelConsumption());

        SportCar sportCar = new SportCar(75, 300);
        System.out.println(sportCar.getFuelConsumption());
    }
}