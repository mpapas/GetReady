namespace GetReady.Domain.Commands
{
    public class PutOnHeadwearCommand : IGetReadyCommand, ICommandFactory
    {
        public string Execute()
        {
            return GetReady.PutOnHeadwear();
        }

        public IGetReady GetReady { get; set; }
        public string CommandName => "2";
        public string Description => "Put on headwear";
        public ICommand CreateCommand(IGetReady getReady)
        {
            return new PutOnHeadwearCommand { GetReady = getReady };
        }
    }
}
