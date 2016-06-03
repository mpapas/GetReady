using System;
using System.Collections.Generic;
using System.Linq;
using GetReady.Domain.Commands;

namespace GetReady.Domain
{
    public class CommandParser
    {
        public static readonly IEnumerable<ICommandFactory> AvailableCommands = GetAvailableCommands();

        public static TemperatureType ParseTemperatureType(string[] commandStringArgs)
        {
            var temperatureTypeString = commandStringArgs[0].ToUpper();

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

        public static IEnumerable<ICommand> ParseCommands(string[] commandStringArgs, IGetReady getReady)
        {
            if (commandStringArgs == null || commandStringArgs.Length == 0)
                throw new ArgumentException("commandStringArgs argument cannot be null or zero length");

            var sanitizedGetReadyCommandStrings = ParseGetReadyCommandStrings(commandStringArgs);

            return sanitizedGetReadyCommandStrings.Select(t => ParseCommand(t, getReady)).ToList();
        }

        private static ICommand ParseCommand(string commandString, IGetReady getReady)
        {
            var command = FindRequestedCommand(commandString);
            if (null == command)
                return new UnrecognizedCommand { Name = commandString };

            return command.CreateCommand(getReady);
        }

        private static ICommandFactory FindRequestedCommand(string commandName)
        {
            return AvailableCommands
                .FirstOrDefault(cmd => cmd.CommandName == commandName);
        }

        private static string[] ParseGetReadyCommandStrings(string[] commandStringArgs)
        {
            var numericCommands = new List<string>();

            string[] arrayToProcess = commandStringArgs;

            if (commandStringArgs.Length == 1)
            {
                arrayToProcess = commandStringArgs[0].Split(' ');
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

        private static IEnumerable<ICommandFactory> GetAvailableCommands()
        {
            return new ICommandFactory[]
                {
                    new TakeOffPajamasCommand(),
                    new PutOnFootwearCommand(),
                    new PutOnHeadwearCommand(),
                    new PutOnShirtCommand(),
                    new PutOnSocksCommand(),
                    new PutOnJacketCommand(),
                    new PutOnPantsCommand(),
                    new LeaveHouseCommand(),
                };
        }

    }
}
