using System;
using System.Collections.Generic;
using System.Text;

namespace Military_Elite
{
    public interface IRepair
    {
        string PartName { get; set; }
        int WorkedHours { get; set; }
    }
}
