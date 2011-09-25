namespace JBG.Minnox.Alarm.Devices
{
    public interface IKeymap
    {
        char[][] Keys { get; }
        char CancelKey { get; }
        char ConfirmKey { get; }
    }
}