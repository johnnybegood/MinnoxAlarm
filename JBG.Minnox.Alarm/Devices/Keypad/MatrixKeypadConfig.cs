using System;
using JBG.Minnox.Alarm.Contracts;
using Microsoft.SPOT.Hardware;

namespace JBG.Minnox.Alarm.Devices.Keypad
{
    public class MatrixKeypadConfig
    {
        public IUserStore UserStore { get; set; }

        public Cpu.Pin[] RowPins { get; set; }

        public Cpu.Pin[] ColPins { get; set; }

        public IKeymap KeyMap { get; set; }
    }
}