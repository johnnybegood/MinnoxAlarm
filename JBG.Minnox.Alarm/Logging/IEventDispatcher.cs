namespace JBG.Minnox.Alarm.Logging
{
    public interface IEventDispatcher
    {
        void Dispatch(IEvent @event);
    }
}