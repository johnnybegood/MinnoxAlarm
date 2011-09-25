using JBG.Minnox.Alarm.Contracts;

namespace JBG.Minnox.Alarm.Devices
{
    public interface IDevice
    {
        void Initialize(ICommandHandler handler);
    }
}