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

        public IIndicatorUpdate IndicatorUpdate
        {
            get { return new TurnedOnIndicatorUpdate(_initiator); }
        }

        #region ICommand Members

        public void Execute(IAlarm alarm)
        {
            alarm.TurnOn();
            alarm.IndicatorDispatcher.Dispatch(new TurnedOnIndicatorUpdate(_initiator));
        }

        #endregion
    }
}