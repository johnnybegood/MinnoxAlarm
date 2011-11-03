using System.Threading;
using Microsoft.SPOT.Hardware;

namespace JBG.Minnox.Alarm.Helpers
{
   public static class Input
    {
       public static bool DebounceReadHigh(InputPort port)
       {
           if (port.Read())
           {
               Thread.Sleep(50);
               return port.Read();
           }

           return false;
       }

       public static bool DebounceReadLow(InputPort port)
       {
           if (!port.Read())
           {
               Thread.Sleep(50);
               return !port.Read();
           }

           return false;
       }
    }
}
