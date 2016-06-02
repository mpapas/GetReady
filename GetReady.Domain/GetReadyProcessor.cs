using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GetReady.Domain;
using GetReady.Domain.Commands;

namespace GetReady.Domain
{
    public class GetReadyProcessor
    {
        public string GetReady(string[] commandStrings)
        {
            var commandStringParser = new CommandStringParser(commandStrings);

            IGetReady getReady;

            if (commandStringParser.Temperature == TemperatureType.HOT)
            {
                getReady = new GetReadyHotWeatherStrategy();
            }
            else
            {
                getReady = new GetReadyColdWeatherStrategy();
            }

            var availableCommands = GetAvailableCommands();

            var commandParser = new CommandParser(availableCommands, getReady);

            var commands = commandParser.ParseCommands(commandStringParser.GetReadyCommandStrings);

            StringBuilder sb = new StringBuilder();

            foreach (var response in commands.Select(command => command.Execute()))
            {
                sb.Append(response + ", ");
                if (response == Constants.Fail)
                    break;
            }

            return sb.ToString().TrimEnd(',', ' ');
        }

        private IEnumerable<ICommandFactory> GetAvailableCommands()
        {
            return new ICommandFactory[]
                {
                    new TakeOffPajamasCommand(),
                    new PutOnFootwearCommand(), 
                    new PutOnHeadwearCommand(), 
                    new PutOnShirtCommand(),
                    new LeaveHouseCommand(),
                    new PutOnSocksCommand(), 
                    new PutOnJacketCommand(), 
                    new PutOnPantsCommand(), 
                };
        }

    }
}
