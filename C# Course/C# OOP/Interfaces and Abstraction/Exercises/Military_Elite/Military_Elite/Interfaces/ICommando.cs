using System.Collections.Generic;

namespace Military_Elite.Interfaces
{
    public interface ICommando : ISpecialisedSoldier
    {
        ICollection<IMission> Missions { get; }
    }
}
