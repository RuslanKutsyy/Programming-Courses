using Military_Elite.Interfaces;
using System.Collections.Generic;
using System.Text;

namespace Military_Elite.Models
{
    public class LieutenantGeneral : Private, ILieutenantGeneral
    {
        public Dictionary<string, IPrivate> Privates { get; set; }

        public LieutenantGeneral(string id, string firstName, string lastName, decimal salary, Dictionary<string, IPrivate> privates) 
            : base(id, firstName, lastName, salary)
        {
            this.Privates = privates;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.ToString());
            sb.AppendLine("Privates:");

            foreach (var privateSoldier in this.Privates)
            {
                sb.AppendLine("  " + privateSoldier.Value.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
