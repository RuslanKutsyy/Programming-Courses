using System;
using System.Collections.Generic;
using System.Text;

namespace Military_Elite
{
    public interface IEngineer : ISpecialisedSoldier
    {
        List<Repair> Repairs { get; set; }
    }
}
