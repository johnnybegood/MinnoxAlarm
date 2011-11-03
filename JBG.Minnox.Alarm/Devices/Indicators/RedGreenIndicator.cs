using System;
using System.Threading;
using JBG.Minnox.Alarm.Logging;
using Microsoft.SPOT.Hardware;

namespace JBG.Minnox.Alarm.Devices.Indicators
{
    public class RedGreenIndicator : IIndicator
    {
        private Timer _timer;
        private readonly OutputPort _greenPort;
        private readonly OutputPort _redPort;
        private bool _blinkRed;
        private DateTime _lastSwitch;

        public RedGreenIndicator(Cpu.Pin greenPin, Cpu.Pin redPin)
        {
            _greenPort = new OutputPort(greenPin, false);
            _redPort = new OutputPort(redPin, false);
            _blinkRed = false;

            _timer = new Timer(SwitchLight, false, 250, 250);
        }

        public void ReceiveEvent(IEvent receivedEvent)
        {
            _blinkRed = receivedEvent is AlarmTriggerdEvent;
            _greenPort.Write(receivedEvent is DeactivatedEvent || receivedEvent is BootEvent);
            _redPort.Write(receivedEvent is ActivatedEvent);
        }

        private void SwitchLight(object status)
        {
            if (_blinkRed)
            {
                _redPort.Write(!_redPort.Read());
            }
        }

    }
}
