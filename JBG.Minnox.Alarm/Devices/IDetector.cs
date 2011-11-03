using JBG.Minnox.Alarm.Contracts;

namespace JBG.Minnox.Alarm.Devices
{
    public interface IDetector : IActor
    {
        string Name { get; }
        bool IsInTriggerdState();
    }
}