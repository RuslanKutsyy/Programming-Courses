using System;

namespace DefiningClasses
{
    public class Person
    {
        private string name { get; set; }
        private int age { get; set; }

        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }

        public int Age
        {
            get { return this.age; }
            set { this.age = value; }
        }

        public Person()
        {
            Name = "No name";
            Age = 1;
        }

        public Person(int age)
        {
            this.Name = "No name";
            this.Age = age;
        }

        public Person(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }
    }

    public class StartUp
    {
        static void Main(string[] args)
        {
            Person personOne = new Person();
            Person anotherPerson = new Person(int.Parse(Console.ReadLine()));

            string name = Console.ReadLine();
            int age = int.Parse(Console.ReadLine());
            Person thirdPerson = new Person(name, age);

            Console.WriteLine($"{personOne.Name} {personOne.Age}");
            Console.WriteLine($"{anotherPerson.Name} {anotherPerson.Age}");
            Console.WriteLine($"{thirdPerson.Name} {thirdPerson.Age}");
        }
    }
}
