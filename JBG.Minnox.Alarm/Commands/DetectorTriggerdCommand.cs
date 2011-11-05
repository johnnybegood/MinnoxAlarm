using JBG.Minnox.Alarm.Contracts;
using JBG.Minnox.Alarm.Devices;
using JBG.Minnox.Alarm.Logging;

namespace JBG.Minnox.Alarm.Commands
{
    public class DetectorTriggerdCommand : ICommand
    {
        private readonly IDetector _detector;

        public DetectorTriggerdCommand(IDetector detector)
        {
            _detector = detector;
        }

        public void Execute(IAlarm alarm)
        {
            if (alarm.CurrentStatus != AlarmStatus.Activated) return;

            alarm.Trigger();
            alarm.EventDispatcher.Dispatch(new AlarmTriggerdEvent(_detector));
        }
    }
}