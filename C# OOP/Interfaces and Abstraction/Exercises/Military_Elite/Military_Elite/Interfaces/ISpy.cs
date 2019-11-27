using System;
using System.Collections.Generic;
using System.Text;

namespace Military_Elite
{
    public interface ISpy : ISoldier
    {
        int CodeNumber { get; set; }
    }
}
