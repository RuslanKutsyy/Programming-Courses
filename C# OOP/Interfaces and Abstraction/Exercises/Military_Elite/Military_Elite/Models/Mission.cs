using System;
using System.Collections.Generic;
using System.Text;

namespace Military_Elite
{
    public class Mission
    {
        private string state;

        public string CodeName { get; set; }
        public string State
        {
            get { return this.state; }
            set
            {
                if (value == "inProgress" || value == "finished")
                {
                    this.state = value;
                }
            }
        }

        public Mission(string codeName, string state)
        {
            this.CodeName = codeName;
            this.State = state;
        }

        public void CompleteMission()
        {
            this.State = "Finished";
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"  Code Name: {this.CodeName} State: {this.State}");

            return sb.ToString().Trim();
        }
    }
}
