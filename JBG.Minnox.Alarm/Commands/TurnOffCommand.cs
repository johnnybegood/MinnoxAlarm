using JBG.Minnox.Alarm.Contracts;
using JBG.Minnox.Alarm.Logging;

namespace JBG.Minnox.Alarm.Commands
{
    public class TurnOffCommand : ICommand
    {
        private readonly string _initiator;

        public TurnOffCommand(string initiator)
        {
            _initiator = initiator;
        }

        public void Execute(IAlarm alarm)
        {
            alarm.Deactivate();
            alarm.EventDispatcher.Dispatch(new DeactivatedEvent(_initiator));
        }
    }
}
