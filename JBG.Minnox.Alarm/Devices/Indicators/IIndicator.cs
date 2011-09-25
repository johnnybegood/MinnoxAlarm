using JBG.Minnox.Alarm.Logging;

namespace JBG.Minnox.Alarm.Devices.Indicators
{
    public interface IIndicator : IDevice
    {
        void ReceiveStatusUpdate(IIndicatorUpdate indicatorUpdate);
    }
}