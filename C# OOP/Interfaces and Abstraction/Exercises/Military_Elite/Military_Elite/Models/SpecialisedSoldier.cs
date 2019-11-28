using Military_Elite.Emums;
using Military_Elite.Interfaces;

namespace Military_Elite
{
    public class SpecialisedSoldier : Private, ISpecialisedSoldier
    {
        public Corps Corps { get; }

        public SpecialisedSoldier(string id, string firstName, string lastName, decimal salary, Corps corps) : base(id, firstName, lastName, salary)
        {
            this.Corps = corps;
        }
    }
}