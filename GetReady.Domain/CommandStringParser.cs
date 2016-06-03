using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace GetReady.Domain
{
    public class CommandStringParser
    {
        private readonly string[] _commandStringArgs;
        private readonly string[] _getReadyCommandStrings;
        private readonly TemperatureType _temperatureType;

        public CommandStringParser(string commandString) : this(new []{commandString})
        { 
        }

        public CommandStringParser(string[] commandStringArgs)
        {
            if (commandStringArgs == null || commandStringArgs.Length == 0)
                throw new ArgumentException("commandStringArgs argument cannot be null or zero length");

            _commandStringArgs = commandStringArgs;

            _temperatureType = ParseTemperatureType();

            _getReadyCommandStrings = ParseGetReadyCommandStrings();
        }

        private TemperatureType ParseTemperatureType()
        {
            var temperatureTypeString = _commandStringArgs[0].ToUpper();

            if (temperatureTypeString.Contains(' '))
            {
                var parts = temperatureTypeString.Split(' ');
                temperatureTypeString = parts[0];
            }

            if (temperatureTypeString != "HOT" && temperatureTypeString != "COLD")
                throw new Exception("First argument must be either 'HOT' or 'COLD'");

            return (TemperatureType)
                Enum.Parse(typeof(TemperatureType), temperatureTypeString);
        }

        private string[] ParseGetReadyCommandStrings()
        {
            var numericCommands = new List<string>();

            string[] arrayToProcess = _commandStringArgs;

            if (_commandStringArgs.Length == 1)
            {
                arrayToProcess = _commandStringArgs[0].Split(' ');
            }

            if (arrayToProcess.Length > 1)
            {
                for (int i = 1; i < arrayToProcess.Length; i++)
                {
                    var cmds = arrayToProcess[i].Split(',');

                    numericCommands.AddRange(cmds.Where(t => !string.IsNullOrWhiteSpace(t)));
                }
            }

            return numericCommands.ToArray();
        }

        public TemperatureType Temperature => _temperatureType;

        public string[] GetReadyCommandStrings => _getReadyCommandStrings;
    }
}
