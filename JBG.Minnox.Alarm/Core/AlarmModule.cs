using JBG.Minnox.Alarm.Commands;
using JBG.Minnox.Alarm.Contracts;
using JBG.Minnox.Alarm.Devices;
using JBG.Minnox.Alarm.Devices.Indicators;
using JBG.Minnox.Alarm.Extensions;
using JBG.Minnox.Alarm.Logging;
using Microsoft.SPOT;

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
            IndicatorDispatcher = new IndicatorDispatcher(DeviceSelector.GetIndicators(_config.Devices));

            Initialize();
        }

        #region IAlarm Members

        public void Trigger(IDetector detector)
        {
            if (CurrentStatus == AlarmStatus.On)
                Debug.Print("Alarm triggerd on: " + detector.Name);
        }

        public AlarmStatus CurrentStatus { get; private set; }

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

        public IIndicatorDispatcher IndicatorDispatcher { get; private set; }

        #endregion

        private void Initialize()
        {
            foreach (var sensor in _config.Devices)
                sensor.Initialize(_handler);

            _connector.Connect();
        }

        public void Loop()
        {
            var runtimeDevices = DeviceSelector.GetRuntimeDevices(_config.Devices);

            foreach (var device in runtimeDevices)
            {
                device.Loop();
            }
        }
    }
}