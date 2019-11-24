namespace Border_Control
{
    public class Robot : IIdentifiable
    {
        public string Id { get; set; }
        string Model { get; set; }

        public Robot(string model, string id)
        {
            this.Model = model;
            this.Id = id;
        }
    }
}
