namespace GetReady.Domain
{
    public interface IGetReadyProcessor
    {
        string GetReady(string commandString);

        string GetReady(string[] commandStrings);
    }
}