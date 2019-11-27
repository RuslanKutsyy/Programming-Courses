using System;
using System.Collections.Generic;
using System.Text;

namespace Military_Elite
{
    public class Repair
    {
        public string PartName { get; set; }
        public int WorkedHours { get; set; }

        public Repair(string partName, int hours)
        {
            this.PartName = partName;
            this.WorkedHours = hours;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Part Name: {this.PartName} Hours Worked: {this.WorkedHours}");

            return sb.ToString().Trim();
        }
    }
}
