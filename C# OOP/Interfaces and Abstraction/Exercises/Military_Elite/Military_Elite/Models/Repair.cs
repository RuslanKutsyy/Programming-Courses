using Military_Elite.Interfaces;

namespace Military_Elite
{
    public class Repair : IRepair
    {
        public string PartName { get; }
        public int WorkedHours { get; }

        public Repair(string partName, int hours)
        {
            this.PartName = partName;
            this.WorkedHours = hours;
        }

        public override string ToString()
        {
            return $"Part Name: {this.PartName} Hours Worked: {this.WorkedHours}";
        }
    }
}
