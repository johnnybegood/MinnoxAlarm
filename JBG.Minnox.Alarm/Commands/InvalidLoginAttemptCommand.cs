using JBG.Minnox.Alarm.Contracts;
using JBG.Minnox.Alarm.Logging;

namespace JBG.Minnox.Alarm.Commands
{
    public class InvalidLoginAttemptCommand : ICommand
    {
        public void Execute(IAlarm alarm)
        {
            alarm.EventDispatcher.Dispatch(new InvalidLoginAttemptStatus());
        }
    }
}