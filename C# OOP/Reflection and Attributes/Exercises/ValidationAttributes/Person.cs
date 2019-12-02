using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;

namespace ValidationAttributes
{
    public class Person
    {
        public string FullName { get; set; }
        public int Age { get; set; }

        public Person(string fullName, int age)
        {
            this.FullName = fullName;
            this.Age = age;
        }


    }
}
