using Military_Elite.Emums;
using Military_Elite.Interfaces;

namespace Military_Elite.Models
{
    public class Mission : IMission
    {
        public string CodeName { get; }
        public State State { get; private set; }

        public Mission(string codeName, State state)
        {
            this.CodeName = codeName;
            this.State = state;
        }

        public void CompleteMission()
        {
            this.State = State.Finished;
        }

        public override string ToString()
        {
            return $"Code Name: {this.CodeName} State: {this.State}";
        }
    }
}
