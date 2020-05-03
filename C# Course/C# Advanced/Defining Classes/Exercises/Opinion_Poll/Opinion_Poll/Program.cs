using System;
using System.Collections.Generic;
using System.Linq;

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

    //public class Family
    //{
    //    private List<Person> members;

    //    public List<Person> Members
    //    {
    //        get { return this.members; }
    //        set { this.members = value; }
    //    }

    //    public void AddMember(Person member)
    //    {
    //        this.Members.Add(member);
    //    }

    //    public Person GetOldestMember()
    //    {
    //        int maxAge = int.MinValue;
    //        Person oldest = null;
    //        for (int i = 0; i < this.Members.Count; i++)
    //        {
    //            if (members[i].Age > maxAge)
    //            {
    //                maxAge = members[i].Age;
    //                oldest = members[i];
    //            }
    //        }

    //        return oldest;
    //    }
    //}

    public class StartUp
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            List<Person> people = new List<Person>();

            for (int i = 0; i < num; i++)
            {
                var data = Console.ReadLine().Split().ToArray();
                string name = data[0];
                int age = int.Parse(data[1]);

                Person person = new Person(name, age);
                people.Add(person);
            }

            var filteredList = people.Where(x => x.Age > 30).OrderBy(x => x.Name);

            foreach (var person in filteredList)
            {
                Console.WriteLine($"{person.Name} - {person.Age}");
            }
        }
    }
}