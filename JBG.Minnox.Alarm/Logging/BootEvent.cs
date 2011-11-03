namespace JBG.Minnox.Alarm.Logging
{
    public class BootEvent : IEvent
    {
        public string Message
        {
            get { return "Alarm boot completed"; }
        }
    }
}
