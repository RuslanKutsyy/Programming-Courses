using System;
using System.Collections.Generic;
using System.Text;

namespace Border_Control
{
    public class Citizen : IIdentifiable
    {
        string Name { get; }
        int Age { get; }
        public string Id { get; }

        public Citizen(string name, int age, string id)
        {
            this.Name = name;
            this.Age = age;
            this.Id = id;
        }
    }
}
