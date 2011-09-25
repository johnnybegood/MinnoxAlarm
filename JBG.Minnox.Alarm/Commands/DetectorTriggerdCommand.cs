using JBG.Minnox.Alarm.Contracts;
using JBG.Minnox.Alarm.Devices;

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
            alarm.Trigger(_detector);
        }
    }
}