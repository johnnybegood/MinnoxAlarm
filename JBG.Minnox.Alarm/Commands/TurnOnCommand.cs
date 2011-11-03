using JBG.Minnox.Alarm.Contracts;
using JBG.Minnox.Alarm.Logging;

namespace JBG.Minnox.Alarm.Commands
{
    public class TurnOnCommand : ICommand
    {
        private readonly string _initiator;

        public TurnOnCommand(string initiator)
        {
            _initiator = initiator;
        }

        #region ICommand Members

        public void Execute(IAlarm alarm)
        {
            alarm.TurnOn();
            alarm.EventDispatcher.Dispatch(new ActivatedEvent(_initiator));
        }

        #endregion
    }
}