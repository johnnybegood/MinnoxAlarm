using JBG.Minnox.Alarm.Devices;

namespace JBG.Minnox.Alarm.Logging
{
    public class AlarmTriggerdEvent : IEvent
    {
        private readonly IDetector _detector;

        public AlarmTriggerdEvent(IDetector detector)
        {
            _detector = detector;
        }

        public string Message
        {
            get { return "Alarm triggerd: " + _detector.Name; }
        }
    }
}
