using System.Collections;
using JBG.Minnox.Alarm.Devices;
using JBG.Minnox.Alarm.Devices.Indicators;

namespace JBG.Minnox.Alarm.Helpers
{
    public static class DeviceSelector
    {
        public static IIndicator[] GetIndicators (IDevice[] devices)
        {
            var list = new ArrayList();
            foreach (var device in devices)
            {
                var indicator = device as IIndicator;

                if (indicator != null) list.Add(indicator);
            }

            return (IIndicator[]) list.ToArray(typeof (IIndicator));
        }

        public static IRuntimeDevice[] GetRuntimeDevices(IDevice[] devices)
        {
            var list = new ArrayList();

            foreach (var device in devices)
            {
                var runtimeDevice = device as IRuntimeDevice;

                if (runtimeDevice != null) list.Add(runtimeDevice);
            }

            return (IRuntimeDevice[])list.ToArray(typeof(IRuntimeDevice));
        }

        public static IActor[] GetActors(IDevice[] devices)
        {
            var list = new ArrayList();

            foreach (var device in devices)
            {
                var actor = device as IActor;

                if (actor != null) list.Add(actor);
            }

            return (IActor[])list.ToArray(typeof(IActor));
        }
    }
}
