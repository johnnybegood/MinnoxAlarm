using JBG.Minnox.Alarm.Commands;
using JBG.Minnox.Alarm.Contracts;
using JBG.Minnox.Alarm.Helpers;
using Microsoft.SPOT.Hardware;

namespace JBG.Minnox.Alarm.Devices.Keypad
{
    public class MatrixKeypad : IKeypad, IRuntimeDevice
    {
        private readonly OutputPort[] _colPorts;
        private readonly MatrixKeypadConfig _config;
        private readonly InputPort[] _rowPorts;
        private ICommandHandler _handler;
        private string _password;

        public MatrixKeypad(MatrixKeypadConfig config)
        {
            _config = config;
            _colPorts = new OutputPort[config.ColPins.Length];
            _rowPorts = new InputPort[config.RowPins.Length];

            CreateColPorts(config.ColPins);
            CreateRowPorts(config.RowPins);
        }

        #region IKeypad Members

        public void Initialize(ICommandHandler handler)
        {
            _handler = handler;
        }

        #endregion

        #region IRuntimeDevice Members

        public void Loop()
        {
            char character = GetChar();

            if (character == _config.KeyMap.CancelKey)
            {
                _password = string.Empty;
            }
            else if (character == _config.KeyMap.ConfirmKey)
            {
                ValidateCodeResult user = _config.UserStore.ValidateCode(_password);

                if (user.IsValidCode)
                    _handler.Handle(new SwitchOnOffCommand(user.ValidatedUser));
                else
                    _handler.Handle(new InvalidLoginAttemptCommand());

                _password = string.Empty;
            }
            else if (character != char.MaxValue)
            {
                _password += character;
            }
        }

        #endregion

        private void CreateRowPorts(Cpu.Pin[] rowPins)
        {
            for (int index = 0; index < rowPins.Length; index++)
            {
                Cpu.Pin pin = rowPins[index];
                _rowPorts[index] = new InputPort(pin, true, Port.ResistorMode.PullUp);
            }
        }

        private void CreateColPorts(Cpu.Pin[] colPins)
        {
            for (int index = 0; index < colPins.Length; index++)
            {
                _colPorts[index] = new OutputPort(colPins[index], true);
            }
        }

        private char GetChar()
        {
            for (int col = 0; col < _colPorts.Length; col++)
            {
                OutputPort outputPort = _colPorts[col];
                outputPort.Write(false);

                for (int row = 0; row < _rowPorts.Length; row++)
                {
                    InputPort interruptPort = _rowPorts[row];

                    if (Input.DebounceReadLow(interruptPort))
                    {
                        while (!interruptPort.Read())
                        {
                            //Wait for keyup
                        }
                        return _config.KeyMap.Keys[row][col];
                    }
                }

                outputPort.Write(true);
            }

            return char.MaxValue;
        }
    }
}