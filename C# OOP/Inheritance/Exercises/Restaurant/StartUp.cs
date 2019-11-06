namespace Restaurant
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            Beverage beverage = new Beverage("beer", 3.45m, 500);
            System.Console.WriteLine(beverage.Price);

            Cake cake = new Cake("tort", 5.50m, 230, 350);
            System.Console.WriteLine($"{cake.Grams}, {cake.Calories}, {cake.CakePrice}");
        }
    }
}