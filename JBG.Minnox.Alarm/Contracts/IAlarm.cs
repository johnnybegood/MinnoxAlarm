using JBG.Minnox.Alarm.Commands;
using JBG.Minnox.Alarm.Devices;
using JBG.Minnox.Alarm.Logging;

namespace JBG.Minnox.Alarm.Contracts
{
    public interface IAlarm
    {
        void Trigger(IDetector detector);
        AlarmStatus CurrentStatus { get; }
        void Receive(ICommand command);
        void TurnOn();
        void TurnOff();

        IIndicatorDispatcher IndicatorDispatcher { get; }
    }
}