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
            Name = "Pesho";
            Age = 20;
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
            Person anotherPerson = new Person("Gosho", 18);
            Person thirdPerson = new Person("Stamat", 43);

            Console.WriteLine($"{personOne.Name} {personOne.Age}");
            Console.WriteLine($"{anotherPerson.Name} {anotherPerson.Age}");
            Console.WriteLine($"{thirdPerson.Name} {thirdPerson.Age}");
        }
    }
}
