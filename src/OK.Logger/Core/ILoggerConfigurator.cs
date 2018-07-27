namespace OK.Logger
{
    public interface ILoggerConfigurator
    {
        ILoggerConfigurator SetProvider(ILoggerProvider provider);

        ILoggerConfigurator EnableInternalLog(string path);
    }
}