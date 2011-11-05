using JBG.Minnox.Alarm.Commands;
using JBG.Minnox.Alarm.Contracts;
using JBG.Minnox.Alarm.Devices.Indicators;
using JBG.Minnox.Alarm.Logging;

namespace JBG.Minnox.Alarm.Devices
{
    public class InvalidLoginDetector : IDetector, IEventReceiver
    {
        private readonly int _maxLoginAttempts;
        private ICommandHandler _handler;
        private int _attempts;

        public InvalidLoginDetector(int maxLoginAttempts)
        {
            _maxLoginAttempts = maxLoginAttempts;
        }

        public void Initialize(ICommandHandler handler)
        {
            _handler = handler;
        }

        public string Name
        {
            get { return "Maximum invalid login detector"; }
        }

        public bool IsInTriggerdState()
        {
            return false; // Should never show on overviews
        }

        public void ReceiveEvent(IEvent receivedEvent)
        {
            _attempts = receivedEvent is InvalidLoginEvent ? _attempts + 1 : 0;

            if (_attempts == _maxLoginAttempts)
                _handler.Handle(new DetectorTriggerdCommand(this));
        }
    }
}
