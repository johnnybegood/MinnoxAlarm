using System;
using System.Threading;
using JBG.Minnox.Alarm.Logging;
using Microsoft.SPOT.Hardware;

namespace JBG.Minnox.Alarm.Devices.Indicators
{
    public class RedGreenEventReceiver : IEventReceiver, IDisposable
    {
        private readonly Timer _timer;
        private readonly OutputPort _greenPort;
        private readonly OutputPort _redPort;
        private bool _isAlarm;

        public RedGreenEventReceiver(Cpu.Pin greenPin, Cpu.Pin redPin)
        {
            _greenPort = new OutputPort(greenPin, false);
            _redPort = new OutputPort(redPin, false);
            _timer = new Timer(SwitchLight, false, 250, 250);
        }

        public void ReceiveEvent(IEvent receivedEvent)
        {
            _isAlarm = receivedEvent is AlarmTriggerdEvent;
            var isActive = receivedEvent is ActivatedEvent;
            var isDeactive = receivedEvent is DeactivatedEvent || receivedEvent is BootEvent;

            if ((!_isAlarm && !isActive) && !isDeactive) return; //unkown state

            _redPort.Write(isActive);
            _greenPort.Write(!_isAlarm && !isActive);
        }

        private void SwitchLight(object status)
        {
            if (_isAlarm)
                _redPort.Write(!_redPort.Read());
        }

        public void Dispose()
        {
            _timer.Dispose();
        }
    }
}
