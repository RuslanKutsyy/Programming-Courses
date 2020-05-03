using System;
using System.Collections.Generic;

namespace Animals
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            string cmd = Console.ReadLine();
            List<Animal> cage = new List<Animal>();


            while (cmd != "Beast!")
            {
                var data = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string name = data[0];
                int age = int.Parse(data[1]);
                string gender = data[2];

                if (age >= 0 && name != string.Empty & name != " " && gender != string.Empty && gender != " ")
                {
                    switch (cmd)
                    {
                        case "Dog":
                            {
                                Dog dog = new Dog(name, age, gender);
                                cage.Add(dog);
                                break;
                            }
                        case "Cat":
                            {
                                Cat cat = new Cat(name, age, gender);
                                cage.Add(cat);
                                break;
                            }
                        case "Frog":
                            {
                                Frog frog = new Frog(name, age, gender);
                                cage.Add(frog);
                                break;
                            }
                        case "Kitten":
                            {
                                Kitten kitten = new Kitten(name, age);
                                cage.Add(kitten);
                                break;
                            }
                        case "Tomcat":
                            {
                                Tomcat tomcat = new Tomcat(name, age);
                                cage.Add(tomcat);
                                break;
                            }
                        case "Animal":
                            {
                                Animal animal = new Animal(name, age, gender);
                                cage.Add(animal);
                                break;
                            }
                        default:
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid Input!");
                }
                cmd = Console.ReadLine();
            }

            foreach (var animal in cage)
            {
                Console.WriteLine(animal.ToString());
                animal.ProduceSound();
            }
        }
    }
}
