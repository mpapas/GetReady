namespace GetReady.Domain.Commands
{
    public class PutOnPantsCommand : IGetReadyCommand, ICommandFactory
    {
        public IGetReady GetReady { get; set; }

        public string Execute()
        {
            return GetReady.PutOnPants();
        }

        public string CommandName => "6";
        public string Description => "Put on pants";
        public ICommand CreateCommand(IGetReady getReady)
        {
            return new PutOnPantsCommand { GetReady = getReady };
        }

    }
}
