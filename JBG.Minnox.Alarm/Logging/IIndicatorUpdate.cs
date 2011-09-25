using System;
using Microsoft.SPOT;

namespace JBG.Minnox.Alarm.Logging
{
    public interface IIndicatorUpdate
    {
        string Message { get; }
    }
}
