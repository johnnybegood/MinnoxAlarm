namespace JBG.Minnox.Alarm.Contracts
{
    public interface IUserStore
    {
        ValidateCodeResult ValidateCode(string code);
    }
}