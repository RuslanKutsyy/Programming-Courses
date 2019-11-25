using System;
using System.Collections.Generic;
using System.Text;

namespace Military_Elite
{
    public class Mission
    {
        public string CodeName { get; set; }
        public string State { get; set; }

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
