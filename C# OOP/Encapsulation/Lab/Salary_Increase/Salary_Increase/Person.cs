using System.Text;

namespace PersonsInfo
{
    public class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public decimal Salary { get; set; }

        public Person(string firstName, string lastName, int age, decimal salary)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Age = age;
            this.Salary = salary;
        }

        public void IncreaseSalary(decimal percentage)
        {
            if (this.Age < 30)
            {
                this.Salary += this.Salary * (percentage / 2 / 100);
            }
            else
            {
                this.Salary += this.Salary * percentage / 100;
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"{this.FirstName} {this.LastName} receives {this.Salary:F2} leva.");
            return sb.ToString();
        }
    }
}
