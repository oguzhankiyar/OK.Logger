using Microsoft.Extensions.DependencyInjection;
using System;

namespace OK.Logger
{
    public static class ServiceCollectionExtensions
    {
        public static void UseOKLogger(this IServiceCollection services, Action<ILoggerConfigurator> configuratorAction)
        {
            ILogger logger = new Logger();

            ILoggerConfigurator configurator = new LoggerConfigurator(logger);

            configuratorAction.Invoke(configurator);

            services.AddTransient((sp) =>
            {
                return logger;
            });
        }
    }
}