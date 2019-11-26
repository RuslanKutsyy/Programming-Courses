using System;
using System.Collections.Generic;
using System.Text;

namespace Military_Elite
{
    public interface ICommando : ISpecialisedSoldier
    {
        List<Mission> Missions { get; set; }
    }
}
