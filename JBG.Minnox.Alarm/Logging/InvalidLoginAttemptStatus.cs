using System;

namespace JBG.Minnox.Alarm.Logging
{
    public class InvalidLoginAttemptStatus : IIndicatorUpdate
    {
        public string Message
        {
            get { return "Invalid login attempt at " + DateTime.Now; }
        }
    }
}