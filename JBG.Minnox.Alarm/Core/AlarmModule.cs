using JBG.Minnox.Alarm.Commands;
using JBG.Minnox.Alarm.Contracts;
using JBG.Minnox.Alarm.Devices;
using JBG.Minnox.Alarm.Helpers;
using JBG.Minnox.Alarm.Logging;

namespace JBG.Minnox.Alarm.Core
{
    public class AlarmModule : IAlarm
    {
        private readonly AlarmConfig _config;
        private readonly ServerConnector _connector;
        private readonly CommandHandler _handler;

        public AlarmModule(AlarmConfig config)
        {
            _config = config;
            _handler = new CommandHandler(this);
            CurrentStatus = AlarmStatus.Off;
            _connector = new ServerConnector(_config.ServerAddress);
            EventDispatcher = new EventDispatcher(DeviceSelector.GetIndicators(_config.Devices));

            Initialize();
        }

        #region IAlarm Members

        public AlarmStatus CurrentStatus { get; private set; }
        public IEventDispatcher EventDispatcher { get; private set; }

        public void Trigger()
        {
            CurrentStatus = AlarmStatus.Triggerd;
        }

        public void Receive(ICommand command)
        {
            command.Execute(this);
        }

        public void TurnOn()
        {
            CurrentStatus = AlarmStatus.On;
        }

        public void TurnOff()
        {
            CurrentStatus = AlarmStatus.Off;
        }

        #endregion

        private void Initialize()
        {
            foreach (IActor sensor in DeviceSelector.GetActors(_config.Devices))
                sensor.Initialize(_handler);

            _connector.Connect();
            new BootCommand().Execute(this);
        }

        public void Loop()
        {
            IRuntimeDevice[] runtimeDevices = DeviceSelector.GetRuntimeDevices(_config.Devices);

            foreach (IRuntimeDevice device in runtimeDevices)
                device.Loop();
        }
    }
}