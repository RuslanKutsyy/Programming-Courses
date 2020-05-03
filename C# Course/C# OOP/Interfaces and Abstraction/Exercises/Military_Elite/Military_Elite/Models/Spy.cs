using System;
using Military_Elite.Interfaces;

namespace Military_Elite
{
    public class Spy : Soldier, ISpy
    {
        public int CodeNumber { get; }

        public Spy(int code, string id, string firstName, string lastName) : base(id, firstName, lastName)
        {
            this.CodeNumber = code;
        }

        public override string ToString()
        {
            return base.ToString() + Environment.NewLine + $"Code Number: {this.CodeNumber}";
        }
    }
}
