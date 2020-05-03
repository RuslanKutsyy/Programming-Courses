using System.Text;

namespace Animals
{
    class Animal
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }

        public Animal(string name, int age, string gender)
        {
            this.Name = name;
            this.Age = age;
            this.Gender = gender;
        }

        public virtual void ProduceSound()
        {
        }

        private bool DataIsValid()
        {
            
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{GetType().Name}");
            sb.Append($"{this.Name} {this.Age} {this.Gender}");

            return sb.ToString().Trim();
        }
    }
}
