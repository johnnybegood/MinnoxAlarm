using JBG.Minnox.Alarm.Commands;
using JBG.Minnox.Alarm.Contracts;

namespace JBG.Minnox.Alarm.Core
{
    public  class CommandHandler : ICommandHandler
    {
        private readonly IAlarm _alarm;

        public CommandHandler(IAlarm alarm)
        {
            _alarm = alarm;
        }

        public void Handle(ICommand command)
        {
            command.Execute(_alarm);
        }
    }
}
