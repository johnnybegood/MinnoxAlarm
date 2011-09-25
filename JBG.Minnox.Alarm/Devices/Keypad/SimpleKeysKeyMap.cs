using System;
using JBG.Minnox.Alarm.Contracts;

namespace JBG.Minnox.Alarm.Devices.Keypad
{
    public class Simple12KeysKeyMap : IKeymap
    {
        private readonly char[][] _keys = new[]
                                                            {
                                                                new[]{'1', '2', '3'},
                                                                new[]{'4', '5', '6'},
                                                                new[]{'7', '8', '9'},
                                                                new[]{'*', '0', '#'}
                                                            };

        public char[][] Keys
        {
            get { return _keys; }
        }

        public char CancelKey
        {
            get { return '*'; }
        }

        public char ConfirmKey
        {
            get { return '#'; }
        }
    }
}
