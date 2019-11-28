using Military_Elite.Interfaces;

namespace Military_Elite
{
    public class Private : Soldier, IPrivate
    {
        public decimal Salary { get; }

        public Private(string id, string firstName, string lastName, decimal salary) : base(id, firstName, lastName)
        {
            this.Salary = salary;
        }

        public override string ToString()
        {
            return base.ToString() + $" Salary: {this.Salary:F2}";
        }
    }
}
