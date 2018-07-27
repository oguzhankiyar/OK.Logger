namespace OK.Logger
{
    public interface ILogger
    {
        void SetProvider(ILoggerProvider provider);

        void EnableInternalLog(string path);

        void Add(string message, object data = null);
    }
}