namespace GetReady.Domain.Commands
{
    public interface IGetReadyCommand : ICommand
    {
        IGetReady GetReady { get; set; }
    }
}
