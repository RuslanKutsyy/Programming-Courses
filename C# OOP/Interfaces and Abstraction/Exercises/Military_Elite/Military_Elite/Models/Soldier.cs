using Military_Elite.Interfaces;

namespace Military_Elite
{
    public class Soldier : ISoldier
    {
        public string ID { get; }
        public string FirstName { get; }
        public string LastName { get; }

        public Soldier(string id, string firstName, string lastName)
        {
            this.ID = id;
            this.FirstName = firstName;
            this.LastName = lastName;
        }

        public override string ToString()
        {
            return $"Name: {this.FirstName} {this.LastName} Id: {this.ID}";
        }
    }
}
