namespace GetReady.Domain.Commands
{
    public class PutOnShirtCommand : IGetReadyCommand, ICommandFactory
    {
        public string Execute()
        {
            return GetReady.PutOnShirt();
        }

        public string CommandName => "4";
        public string Description => "Put on shirt";
        public ICommand CreateCommand(IGetReady getReady)
        {
            return new PutOnShirtCommand { GetReady = getReady };
        }

        public IGetReady GetReady { get; set; }
    }
}
