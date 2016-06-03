using System.Collections.Generic;
using System.Linq;
using System.Text;
using GetReady.Domain.Commands;

namespace GetReady.Domain
{
    public class GetReadyProcessor : IGetReadyProcessor
    {
        public string GetReady(string commandString)
        {
            return GetReady(new []{commandString});
        }

        public string GetReady(string[] commandStrings)
        {
            var getReady = GetReadyStrategy.Create(CommandParser.ParseTemperatureType(commandStrings));

            var commands = CommandParser.ParseCommands(commandStrings, getReady);

            return ExecuteCommands(commands);
        }

        private string ExecuteCommands(IEnumerable<ICommand> commandsToExecute)
        {
            StringBuilder sb = new StringBuilder();

            foreach (var response in commandsToExecute.Select(command => command.Execute()))
            {
                sb.Append(response + ", ");
                if (response == Constants.Fail)
                    break;
            }

            return sb.ToString().TrimEnd(',', ' ');
        }

        public IEnumerable<ICommandFactory> AvailableCommands => CommandParser.AvailableCommands;
    }
}
