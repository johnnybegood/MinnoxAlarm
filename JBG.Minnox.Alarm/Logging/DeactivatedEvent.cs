namespace JBG.Minnox.Alarm.Logging
{
    public class DeactivatedEvent : IEvent
    {
        private readonly string _initiator;

        public DeactivatedEvent(string initiator)
        {
            _initiator = initiator;
        }

        #region IEvent Members

        public string Message
        {
            get { return "Alarm turned off by " + _initiator; }
        }

        #endregion
    }
}