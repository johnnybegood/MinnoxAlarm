using System;

namespace JBG.Minnox.Alarm.Logging
{
    public class TurnedOnIndicatorUpdate : IIndicatorUpdate
    {
        public TurnedOnIndicatorUpdate(string initiator)
        {
            Initiator = initiator;
        }

        public string Message
        {
            get { return "Alarm turned on by " + Initiator; }
        }

        public string Initiator { get; private set; }
    }
}
