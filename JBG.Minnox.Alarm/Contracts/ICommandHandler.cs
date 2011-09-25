using JBG.Minnox.Alarm.Commands;

namespace JBG.Minnox.Alarm.Contracts
{
    public interface ICommandHandler
    {
        void Handle(ICommand command);
    }
}