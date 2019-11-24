namespace Border_Control
{
    public class Citizen : IIdentifiable
    {
        public string Id { get; set; }
        string Name { get; set; }
        int Age { get; set; }

        public Citizen(string id, string name, int age)
        {
            this.Id = id;
            this.Name = name;
            this.Age = age;
        }
    }
}
