using System;
using System.Collections.Generic;
using System.Text;

namespace Military_Elite
{
    public class Spy : ISpy
    {
        public int CodeNumber { get; set; }
        public string ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public Spy(int code, string id, string firstName, string lastName)
        {
            this.CodeNumber = code;
            this.ID = id;
            this.FirstName = firstName;
            this.LastName = lastName;
        }
    }
}
