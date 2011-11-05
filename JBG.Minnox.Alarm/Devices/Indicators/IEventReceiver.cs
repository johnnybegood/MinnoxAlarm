using JBG.Minnox.Alarm.Logging;

namespace JBG.Minnox.Alarm.Devices.Indicators
{
    public interface IEventReceiver : IDevice
    {
        void ReceiveEvent(IEvent receivedEvent);
    }
}