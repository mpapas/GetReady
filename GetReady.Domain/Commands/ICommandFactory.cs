namespace GetReady.Domain.Commands
{
    public interface ICommandFactory
    {
        string CommandName { get; }
        string Description { get; }

        ICommand CreateCommand(IGetReady getReady);
    }
}
