using OK.Logger.SqlServer.EntityFramework;
using System;

namespace OK.Logger.SqlServer
{
    public class SqlServerProvider : ILoggerProvider
    {
        private readonly ILogRepository _logRepository;

        public SqlServerProvider(ILogRepository logRepository)
        {
            _logRepository = logRepository;
        }

        public void Insert(string message, string data, DateTime date)
        {
            if (string.IsNullOrEmpty(message))
            {
                throw new ArgumentException(nameof(message));
            }
            
            if (date == DateTime.MinValue)
            {
                throw new ArgumentException(nameof(date));
            }

            LogEntity log = new LogEntity()
            {
                Message = message,
                Data = data,
                CreatedAt = date
            };

            _logRepository.Add(log);
        }
    }
}