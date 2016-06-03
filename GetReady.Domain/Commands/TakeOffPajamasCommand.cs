namespace GetReady.Domain.Commands
{
    public class TakeOffPajamasCommand : IGetReadyCommand, ICommandFactory
    {
        public IGetReady GetReady { get; set; }

        public string Execute()
        {
           return GetReady.TakeOffPajamas();
        }

        public string CommandName => "8";
        public string Description => "Take off pajamas";
        public ICommand CreateCommand(IGetReady getReady)
        {
            return new TakeOffPajamasCommand {GetReady = getReady};
        }

    }
}
