using System;
using System.Collections.Generic;
using System.Text;
using Military_Elite.Interfaces;

namespace Military_Elite
{
    public interface ICommando : ISpecialisedSoldier
    {
        List<Mission> Missions { get; set; }
    }
}
