using System;
using System.Collections.Generic;
using System.Text;

namespace Cars
{
    class Seat : ICar
    {
        public string Model { get; set; }
        public string Color { get; set; }

        public Seat(string model, string color)
        {
            this.Model = model;
            this.Color = color;
        }

        public string Start()
        {
            string text = "Engine start";
            return text;
        }

        public string Stop()
        {
            string text = "Breaaak!";
            return text;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{this.Color} Seat {this.Model}");
            sb.AppendLine(this.Start());
            sb.Append(this.Stop());

            return sb.ToString();
        }
    }
}
