using System;

namespace JBG.Minnox.Alarm.Logging
{
    public class InvalidLoginAttemptStatus : IEvent
    {
        public string Message
        {
            get { return "Invalid login attempt at " + DateTime.Now; }
        }
    }
}