using Military_Elite.Emums;

namespace Military_Elite.Interfaces
{
    public interface ISpecialisedSoldier : IPrivate
    {
        Corps Corps { get; }
    }
}
