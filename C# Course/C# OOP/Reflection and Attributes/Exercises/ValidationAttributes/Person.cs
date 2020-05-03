namespace ValidationAttributes
{
    public class Person
    {
        [MyRequired]
        public string FullName { get; set; }

        [MyRange(18, 65)]
        public int Age { get; set; }

        public Person(string fullName, int age)
        {
            this.FullName = fullName;
            this.Age = age;
        }
    }
}
