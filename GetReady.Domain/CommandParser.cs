using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GetReady.Domain;
using GetReady.Domain.Commands;

namespace GetReady.Domain
{
    public class CommandParser
    {
        readonly IEnumerable<ICommandFactory> availableCommands;
        private IGetReady _getReady;

        public CommandParser(IEnumerable<ICommandFactory> availableCommands, IGetReady getReady)
        {
            this.availableCommands = availableCommands;
            _getReady = getReady;
        }

        public static object ConvertToGetDressedRequest(string[] args)
        {
            if (args == null || args.Length == 0)
                throw new ArgumentException("Args cannot be null or zero length");


            var commandNumbers = args[1].Split(',');

            throw new NotImplementedException();
        }


        internal ICommand ParseCommand(string commandString)
        {
            var command = FindRequestedCommand(commandString);
            if (null == command)
                return new UnrecognizedCommand { Name = commandString };

            return command.CreateCommand(_getReady);
        }

        internal IEnumerable<ICommand> ParseCommands(string[] commandStrings)
        {
            List<ICommand> commands = new List<ICommand>();

            for (int i = 0; i < commandStrings.Length; i++)
            {
                commands.Add(ParseCommand(commandStrings[i]));
            }

            return commands;
        }

        ICommandFactory FindRequestedCommand(string commandName)
        {
            return availableCommands
                .FirstOrDefault(cmd => cmd.CommandName == commandName);
        }
    }
}
