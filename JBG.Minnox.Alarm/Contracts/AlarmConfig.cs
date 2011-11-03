using JBG.Minnox.Alarm.Devices;

namespace JBG.Minnox.Alarm.Contracts
{
    public class AlarmConfig
    {
        public IDevice[] Devices { get; set; }

        public string ServerAddress { get; set; }
    }
}