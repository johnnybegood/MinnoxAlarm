using JBG.Minnox.Alarm.Contracts;
using JBG.Minnox.Alarm.Logging;

namespace JBG.Minnox.Alarm.Commands
{
   public class BootCommand : ICommand
    {
       public void Execute(IAlarm alarm)
       {
           alarm.TurnOff();
           alarm.EventDispatcher.Dispatch(new BootEvent());
       }
    }
}
