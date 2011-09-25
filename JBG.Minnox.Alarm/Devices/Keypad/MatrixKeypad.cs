using JBG.Minnox.Alarm.Commands;
using JBG.Minnox.Alarm.Contracts;
using JBG.Minnox.Alarm.Extensions;
using Microsoft.SPOT.Hardware;

namespace JBG.Minnox.Alarm.Devices.Keypad
{
    public class MatrixKeypad : IKeypad, IRuntimeDevice
    {
        private readonly MatrixKeypadConfig _config;
        private ICommandHandler _handler;
        private readonly OutputPort[] _colPorts;
        private readonly InputPort[] _rowPorts;
        private string _password;

        public MatrixKeypad(MatrixKeypadConfig config)
        {
            _config = config;
            _colPorts = new OutputPort[config.ColPins.Length];
            _rowPorts = new InputPort[config.RowPins.Length];

            CreateColPorts(config.ColPins);
            CreateRowPorts(config.RowPins);
        }
        
        public void Initialize(ICommandHandler handler)
        {
            _handler = handler;
        }

        private void CreateRowPorts(Cpu.Pin[] rowPins)
        {
            for (var index = 0; index < rowPins.Length; index++)
            {
                var pin = rowPins[index];
                _rowPorts[index] = new InputPort(pin, true, Port.ResistorMode.PullUp);
            }
        }

        private void CreateColPorts(Cpu.Pin[] colPins)
        {
            for (var index = 0; index < colPins.Length; index++)
            {
                _colPorts[index] = new OutputPort(colPins[index], true);
            }
        }

        public void Loop()
        {
            var character = GetChar();

            if (character == _config.KeyMap.CancelKey)
            {
                _password = string.Empty;
            }
            else if (character == _config.KeyMap.ConfirmKey)
            {
                var user = _config.UserStore.ValidateCode(_password);

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

        private char GetChar()
        {
            for (var col = 0; col < _colPorts.Length; col++)
            {
                var outputPort = _colPorts[col];
                outputPort.Write(false);

                for (var row = 0; row < _rowPorts.Length; row++)
                {
                    var interruptPort = _rowPorts[row];

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