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
                if (value == "inProgress" || value == "Finished")
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
    }
}
