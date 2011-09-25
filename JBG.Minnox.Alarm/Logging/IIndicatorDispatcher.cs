namespace JBG.Minnox.Alarm.Logging
{
    public interface IIndicatorDispatcher
    {
        void Dispatch(IIndicatorUpdate indicatorUpdate);
    }
}