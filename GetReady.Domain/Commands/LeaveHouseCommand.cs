namespace GetReady.Domain.Commands
{
 
    public class LeaveHouseCommand : IGetReadyCommand, ICommandFactory
    {
        public IGetReady GetReady { get; set; }

        public string Execute()
        {
            return GetReady.LeaveHouse();
        }

        public string CommandName => "7";
        public string Description => "Leave house";
        public ICommand CreateCommand(IGetReady getReady)
        {
            return new LeaveHouseCommand { GetReady = getReady };
        }

    }
}
