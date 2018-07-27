using OK.Logger.SqlServer.EntityFramework;
using System;

namespace OK.Logger.SqlServer
{
    public static class ConfiguratorExtensions
    {
        public static ILoggerConfigurator UseSqlServer(this ILoggerConfigurator configurator, string connectionString)
        {
            if (string.IsNullOrEmpty(connectionString))
            {
                throw new ArgumentException(nameof(connectionString));
            }

            LogDataContext context = new LogDataContext(connectionString);

            ILogRepository logRepository = new LogRepository(context);

            ILoggerProvider provider = new SqlServerProvider(logRepository);

            configurator.SetProvider(provider);

            return configurator;
        }
    }
}