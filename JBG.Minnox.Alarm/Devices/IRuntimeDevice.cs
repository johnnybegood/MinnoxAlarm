using System;
using Microsoft.SPOT;

namespace JBG.Minnox.Alarm.Devices
{
    public interface IRuntimeDevice : IDevice
    {
        void Loop();
    }
}
