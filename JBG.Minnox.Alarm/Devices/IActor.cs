using JBG.Minnox.Alarm.Contracts;

namespace JBG.Minnox.Alarm.Devices
{
    public interface IActor : IDevice
    {
        void Initialize(ICommandHandler handler);
    }
}