using System;
using System.Collections.Generic;
using System.Text;

namespace Military_Elite
{
    public class Repair : IRepair
    {
        public string PartName { get; set; }
        public int WorkedHours { get; set; }
    }
}
