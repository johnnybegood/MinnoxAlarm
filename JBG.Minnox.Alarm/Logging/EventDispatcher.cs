using System.Collections;
using JBG.Minnox.Alarm.Devices.Indicators;

namespace JBG.Minnox.Alarm.Logging
{
    public class EventDispatcher : IEventDispatcher
    {
        private readonly IEnumerable _indicators;

        public EventDispatcher(IEnumerable indicators)
        {
            _indicators = indicators;
        }

        public void Dispatch(IEvent update)
        {
            foreach (IEventReceiver indicator in _indicators)
            {
                indicator.ReceiveEvent(update);
            }
        }
    }
}