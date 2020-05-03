using Military_Elite.Emums;
using Military_Elite.Interfaces;
using System.Collections.Generic;
using System.Text;

namespace Military_Elite.Models
{
    class Engineer : SpecialisedSoldier, IEngineer
    {
        public ICollection<IRepair> Repairs { get; }

        public Engineer(string id, string firstName, string lastName, decimal salary, Corps corps, ICollection<IRepair> repairs) :
            base(id, firstName, lastName, salary, corps)
        {
            this.Repairs = repairs;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(base.ToString());
            sb.AppendLine($"Corps: {this.Corps}");
            sb.AppendLine("Repairs:");

            foreach (var repair in Repairs)
            {
                sb.AppendLine("  " + repair.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
