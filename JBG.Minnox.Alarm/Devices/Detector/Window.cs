using System;
using JBG.Minnox.Alarm.Commands;
using JBG.Minnox.Alarm.Contracts;
using Microsoft.SPOT.Hardware;

namespace JBG.Minnox.Alarm.Devices.Detector
{
    public class Window : IDetector
    {
        private readonly bool _pulseOnClose;
        private ICommandHandler _handler;
        private readonly InterruptPort _port;

        public string Name { get; private set; }

        public Window(Cpu.Pin pin, bool pulseOnClose, string name)
        {
            _pulseOnClose = pulseOnClose;
            Name = name;
            _port = new InterruptPort(pin, true, Port.ResistorMode.Disabled, Port.InterruptMode.InterruptEdgeBoth);
            _port.OnInterrupt += PortOnInterrupt;
        }

        void PortOnInterrupt(uint data1, uint data2, DateTime time)
        {
            if (_handler != null && IsInTriggerdState())
                _handler.Handle(new DetectorTriggerdCommand(this));
        }

        public void Initialize(ICommandHandler handler)
        {
            _handler = handler;
        }

        public bool IsInTriggerdState()
        {
            return _port.Read() != _pulseOnClose;
        }
    }
}