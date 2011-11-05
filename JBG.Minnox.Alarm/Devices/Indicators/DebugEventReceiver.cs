using JBG.Minnox.Alarm.Logging;
using Microsoft.SPOT;

namespace JBG.Minnox.Alarm.Devices.Indicators
{
    public class DebugEventReceiver : IEventReceiver
    {
        public void ReceiveEvent(IEvent receivedEvent)
        {
            Debug.Print(receivedEvent.Message);
        }
    }
}
