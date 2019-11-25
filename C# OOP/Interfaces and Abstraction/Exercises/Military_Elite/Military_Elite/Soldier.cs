using System;
using System.Collections.Generic;
using System.Text;

namespace Military_Elite
{
    public class Soldier : ISoldier
    {
        public string ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
