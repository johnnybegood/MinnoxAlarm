using JBG.Minnox.Alarm.Contracts;

namespace JBG.Minnox.Alarm.Commands
{
    public interface ICommand
    {
        void Execute(IAlarm alarm);
    }
}