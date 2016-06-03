using System;
using System.Collections.Generic;
using GetReady.Domain;
using GetReady.Domain.Commands;

namespace GetReady.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            var processor = new GetReadyProcessor();

            if (args.Length == 0 || args[0] == "?" || args[0] == "/?" || args[0] == "\\?")
            {
                PrintUsage(processor.AvailableCommands);
                return;
            }

            try
            {
                Console.WriteLine(processor.GetReady(args));
            }
            catch (Exception ex)
            {
                Console.WriteLine("fail");
                Console.WriteLine(ex.Message);
            }
        }

        private static void PrintUsage(IEnumerable<ICommandFactory> availableCommands)
        {
            Console.WriteLine("\nUsage: GetReady.Client.exe [Temperature] [Command, Command, ...]");
            Console.WriteLine("Example: GetReady.Client.exe HOT 8, 6, 4, 2, 1, 7");
            Console.WriteLine("Temperature: HOT or COLD");
            Console.WriteLine("Commands:");
            foreach (var command in availableCommands)
                Console.WriteLine("\tCommand: {0}, Description: {1}", command.CommandName, command.Description);
        }

    }
}

