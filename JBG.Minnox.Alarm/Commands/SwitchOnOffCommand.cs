using JBG.Minnox.Alarm.Contracts;

namespace JBG.Minnox.Alarm.Commands
{
    public class SwitchOnOffCommand : ICommand
    {
        private readonly string _initiator;

        public SwitchOnOffCommand(string initiator)
        {
            _initiator = initiator;
        }
        
        #region ICommand Members

        public void Execute(IAlarm alarm)
        {
            switch (alarm.CurrentStatus)
            {
                case AlarmStatus.Activated:
                case AlarmStatus.Triggerd:
                    alarm.Receive(new TurnOffCommand(_initiator));
                    break;
                case AlarmStatus.Deactivated:
                    alarm.Receive(new TurnOnCommand(_initiator));
                    break;
            }
        }

        #endregion
    }
}