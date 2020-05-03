using System.Collections.Generic;

namespace Military_Elite.Interfaces
{
    public interface IEngineer : ISpecialisedSoldier
    {
        ICollection<IRepair> Repairs { get; }
    }
}
