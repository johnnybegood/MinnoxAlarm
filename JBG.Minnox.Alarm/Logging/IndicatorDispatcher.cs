using System.Collections;
using JBG.Minnox.Alarm.Devices.Indicators;

namespace JBG.Minnox.Alarm.Logging
{
    public class IndicatorDispatcher : IIndicatorDispatcher
    {
        private readonly IEnumerable _indicators;

        public IndicatorDispatcher(IEnumerable indicators)
        {
            _indicators = indicators;
        }

        public void Dispatch(IIndicatorUpdate update)
        {
            foreach (IIndicator indicator in _indicators)
            {
                indicator.ReceiveStatusUpdate(update);
            }
        }
    }
}