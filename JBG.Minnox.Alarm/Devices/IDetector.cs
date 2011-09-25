using JBG.Minnox.Alarm.Contracts;

namespace JBG.Minnox.Alarm.Devices
{
    public interface IDetector : IDevice
    {
        string Name { get; }
        bool IsInTriggerdState();
    }
}