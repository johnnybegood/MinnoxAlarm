using DeviceSolutions.SPOT.Hardware;
using JBG.Minnox.Alarm.Contracts;
using JBG.Minnox.Alarm.Devices;
using JBG.Minnox.Alarm.Devices.Detector;
using JBG.Minnox.Alarm.Devices.Indicators;
using JBG.Minnox.Alarm.Devices.Keypad;

namespace JBG.Minnox.AlarmModule
{
    public class Program
    {
        public static void Main()
        {
            var config = ConfigAlarm();

            var alarm = new Alarm.Core.AlarmModule(config);

            while (true)
            {
                alarm.Loop();
            }
        }

        private static AlarmConfig ConfigAlarm()
        {
            var matrixKeypadConfig = new MatrixKeypadConfig
                                         {
                                             ColPins = new[]
                                                           {
                                                               Meridian.Pins.GPIO9,
                                                               Meridian.Pins.GPIO5,
                                                               Meridian.Pins.GPIO4,

                                                           },
                                             KeyMap = new Simple12KeysKeyMap(),
                                             RowPins = new[]
                                                           {
                                                               Meridian.Pins.GPIO6,
                                                               Meridian.Pins.GPIO3,
                                                               Meridian.Pins.GPIO7,
                                                               Meridian.Pins.GPIO8
                                                           },
                                             UserStore = new UserStore()
                                         };

            return new AlarmConfig
                       {
                           Devices = new IDevice[]
                                         {
                                             new Window(Meridian.Pins.GPIO1, true, "Bureau"),
                                             new MatrixKeypad(matrixKeypadConfig),
                                             new DebugIndicator(),
                                             new RedGreenIndicator(Meridian.Pins.GPIO2, Meridian.Pins.GPIO10)
                                         },
                           ServerAddress = "192.168.1.20/JBG.Minnox.Director"
                       };
        }
    }
}
