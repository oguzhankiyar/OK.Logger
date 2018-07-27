using System;
using System.IO;

namespace OK.Logger
{
    public class Logger : ILogger
    {
        private ILoggerProvider provider;
        private string internalLogPath;

        public static ILogger New(Action<ILoggerConfigurator> configuratorAction)
        {
            ILogger logger = new Logger();

            ILoggerConfigurator configurator = new LoggerConfigurator(logger);

            configuratorAction.Invoke(configurator);

            return logger;
        }

        public void SetProvider(ILoggerProvider provider)
        {
            this.provider = provider;
        }

        public void EnableInternalLog(string path)
        {
            if (string.IsNullOrEmpty(path))
            {
                throw new ArgumentException(nameof(path));
            }

            internalLogPath = path;
        }

        public void Add(string message, object data = null)
        {
            try
            {
                provider.Insert(message, data?.ToString(), DateTime.Now);
            }
            catch (Exception ex)
            {
                if (!string.IsNullOrEmpty(internalLogPath))
                {
                    object exData = new { OccuredAt = DateTime.Now, Exception = ex };

                    AddInternalLog(exData.ToString());
                }
            }
        }

        #region Helpers

        private void AddInternalLog(string message)
        {
            File.AppendAllText(internalLogPath, message + Environment.NewLine);
        }

        #endregion
    }
}