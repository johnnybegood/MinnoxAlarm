namespace JBG.Minnox.Alarm.Logging
{
    public class ActivatedEvent : IEvent
    {
        private readonly string _initiator;

        public ActivatedEvent(string initiator)
        {
            _initiator = initiator;
        }

        public string Message
        {
            get { return "Alarm activated by " + _initiator; }
        }
    }
}
