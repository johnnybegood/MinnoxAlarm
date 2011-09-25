using JBG.Minnox.Alarm.Contracts;

namespace JBG.Minnox.Alarm.Commands
{
    public class SwitchOnOffCommand : ICommand
    {
        private IAlarm _alarm;

        public SwitchOnOffCommand(string initiator)
        {
            Initiator = initiator;
        }

        public string Initiator { get; private set; }

        #region ICommand Members

        public void Execute(IAlarm alarm)
        {
            switch (alarm.CurrentStatus)
            {
                case AlarmStatus.On:
                    alarm.Receive(new TurnOffCommand(Initiator));
                    break;
                case AlarmStatus.Off:
                    alarm.Receive(new TurnOnCommand(Initiator));
                    break;
            }
        }

        #endregion
    }
}