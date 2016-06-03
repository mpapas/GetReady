using System.Collections.Generic;
using GetReady.Domain.Commands;

namespace GetReady.Domain
{
    public interface IGetReadyProcessor
    {
        string GetReady(string commandString);

        string GetReady(string[] commandStrings);

        IEnumerable<ICommandFactory> AvailableCommands { get; }
    }
}