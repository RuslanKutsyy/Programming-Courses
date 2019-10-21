using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace Filter_by_Age
{
    class Person
    {
        public Person(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }

        public string Name { get; set; }

        public int Age { get; set; }
    }

    class Program
    {

        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<Person> people = new List<Person>();

            for (int i = 0; i < n; i++)
            {
                var data = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).ToArray();
                string name = data[0];
                int age = int.Parse(data[1]);

                var person = new Person(name, age);
                people.Add(person);
            }

            string condition = Console.ReadLine();
            int conditionAge = int.Parse(Console.ReadLine());
            string format = Console.ReadLine();

            Func<Person, bool> predicate = ConditionChecker(condition, conditionAge);
            var filteredPeople = people.Where(predicate);

            Action<Person> printer = PrintData(format);

            foreach (var person in filteredPeople)
            {
                printer(person);
            }
        }

        public static Func<Person, bool> ConditionChecker(string condition, int age)
        {
            switch (condition)
            {
                case "younger": return x => x.Age < age;
                case "older": return x => x.Age >= age;
                default:
                    break;
            }
            return null;
        }

        public static Action<Person> PrintData(string format)
        {
            switch (format)
            {
                case "name": return Person => Console.WriteLine($"{Person.Name}");
                case "age": return Person => Console.WriteLine($"{Person.Age}");
                case "name age": return Person => Console.WriteLine($"{Person.Name} - {Person.Age}");
                default:
                    return null;
            }

        }
    }
}
