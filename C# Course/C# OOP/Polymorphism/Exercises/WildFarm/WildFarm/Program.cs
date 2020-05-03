using System;
using System.Collections.Generic;

namespace WildFarm
{
    public class Program
    {
        static void Main(string[] args)
        {
            var animals = new List<Animal>();

            while (true)
            {
                string cmd = Console.ReadLine();

                if (cmd == "End")
                {
                    break;
                }

                var data = cmd.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string animalType = data[0];
                string name = data[1];
                double weight = double.Parse(data[2]);

                Animal animal = null;

                switch (animalType)
                {
                    case "Owl":
                        {
                            int wingSize = int.Parse(data[3]);

                            animal = new Owl(name, weight, wingSize);
                            break;
                        }
                    case "Hen":
                        {
                            int wingSize = int.Parse(data[3]);

                            animal = new Hen(name, weight, wingSize);
                            break;
                        }
                    case "Mouse":
                        {
                            string region = data[3];

                            animal = new Mouse(name, weight, region);
                            break;
                        }
                    case "Dog":
                        {
                            string region = data[3];

                            animal = new Dog(name, weight, region);
                            break;
                        }
                    case "Cat":
                        {
                            string region = data[3];
                            string breed = data[4];

                            animal = new Cat(name, weight, region, breed);
                            break;
                        }
                    case "Tiger":
                        {
                            string region = data[3];
                            string breed = data[4];

                            animal = new Tiger(name, weight, region, breed);
                            break;
                        }
                    default:
                        break;
                }

                Console.WriteLine(animal.ProduceSound());

                var foodData = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string foodName = foodData[0];
                int foodNum = int.Parse(foodData[1]);

                Food food = null;

                switch (foodName)
                {
                    case "Fruit":
                        {
                            food = new Fruit(foodNum);

                            break;
                        }
                    case "Meat":
                        {
                            food = new Meat(foodNum);
                            break;
                        }
                    case "Seeds":
                        {
                            food = new Seeds(foodNum);
                            break;
                        }
                    case "Vegetable":
                        {
                            food = new Vegetable(foodNum);
                            break;
                        }
                    default:
                        break;
                }

                animal.Feed(food);
                animals.Add(animal);
            }

            foreach (var beast in animals)
            {
                Console.WriteLine(beast.ToString());
            }
        }
    }
}
