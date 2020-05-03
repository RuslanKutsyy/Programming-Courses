using Military_Elite.Emums;

namespace Military_Elite.Interfaces
{
    public interface IMission
    {
        string CodeName { get; }
        State State { get; }

        void CompleteMission();
    }
}
