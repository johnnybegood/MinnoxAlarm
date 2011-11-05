using System;

namespace JBG.Minnox.Alarm.Logging
{
    public class InvalidLoginEvent : IEvent
    {
        public string Message
        {
            get { return "Invalid login attempt at " + DateTime.Now; }
        }
    }
}