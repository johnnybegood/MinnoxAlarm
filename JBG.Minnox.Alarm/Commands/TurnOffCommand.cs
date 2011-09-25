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

        public IIndicatorUpdate IndicatorUpdate { get { return new TurnedOnIndicatorUpdate(_initiator); }}

        public void Execute(IAlarm alarm)
        {
            alarm.TurnOff();
            alarm.IndicatorDispatcher.Dispatch(new TurnedOffIndicatorUpdate(_initiator));
        }
    }
}
