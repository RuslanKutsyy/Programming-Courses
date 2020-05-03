using System;
using System.Collections.Generic;
using System.Text;

namespace Border_Control
{
    public class Robot : IIdentifiable
    {
        string Model { get; }
        public string Id { get; }

        public Robot(string model, string id)
        {
            this.Model = model;
            this.Id = id;
        }
    }
}
