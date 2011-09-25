using System;
using Microsoft.SPOT;

namespace JBG.Minnox.Alarm.Logging
{
   public class TurnedOffIndicatorUpdate: IIndicatorUpdate
    {
       public TurnedOffIndicatorUpdate(string initiator)
       {
           Initiator = initiator;
       }

       public string Message
       {
           get { return "Alarm turned off by " + Initiator; }
       }

       public string Initiator { get; set; }
    }
}
