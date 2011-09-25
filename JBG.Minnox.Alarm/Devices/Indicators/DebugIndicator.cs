using System;
using JBG.Minnox.Alarm.Contracts;
using JBG.Minnox.Alarm.Logging;
using Microsoft.SPOT;

namespace JBG.Minnox.Alarm.Devices.Indicators
{
    public class DebugIndicator : IIndicator
    {
        private ICommandHandler _handler;

        public void ReceiveStatusUpdate(IIndicatorUpdate indicatorUpdate)
        {
            Debug.Print(indicatorUpdate.Message);
        }

        public void Initialize(ICommandHandler handler)
        {
            _handler = handler;
        }
    }
}
