namespace OK.Logger
{
    public class LoggerConfigurator : ILoggerConfigurator
    {
        private readonly ILogger _logger;

        public LoggerConfigurator(ILogger logger)
        {
            _logger = logger;
        }

        public ILoggerConfigurator SetProvider(ILoggerProvider provider)
        {
            _logger.SetProvider(provider);

            return this;
        }

        public ILoggerConfigurator EnableInternalLog(string path)
        {
            _logger.EnableInternalLog(path);

            return this;
        }
    }
}