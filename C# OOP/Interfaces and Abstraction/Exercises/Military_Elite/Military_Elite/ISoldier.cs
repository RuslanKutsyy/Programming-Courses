using System;
using System.Collections.Generic;
using System.Text;

namespace Military_Elite
{
    public interface ISoldier
    {
        string ID { get; set; }
        string FirstName { get; set; }
        string LastName { get; set; }
    }
}
