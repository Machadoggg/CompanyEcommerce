using Company.Ecommerce.Domain.Entity;
using Company.Ecommerce.Infrastructure.Interface;
using Company.Ecommerce.Transversal.Common;
using Microsoft.Extensions.Logging;

namespace Company.Ecommerce.Transversal.Logging
{
    public class LoggerAdapter<T> : IAppLogger<T>
    {
        private readonly ILogger<T> _logger;
        private readonly ILogRepository _logRepository;

        public LoggerAdapter(ILoggerFactory loggerFactory, ILogRepository logRepository)
        {
            _logger = loggerFactory.CreateLogger<T>();
            _logRepository = logRepository;
        }


        public void LogInformation(string message, params object[] args)
        {
            _logger.LogInformation(message, args);
            SaveLog("Information", string.Format(message, args));
        }

        public void LogWarning(string message, params object[] args)
        {
            _logger.LogWarning(message, args);
            SaveLog("Warning", string.Format(message, args));
        }

        public void LogError(string message, params object[] args)
        {
            _logger.LogError(message, args);
            SaveLog("Error", string.Format(message, args));
        }


        private void SaveLog(string logLevel, string message)
        {
            var log = new Log
            {
                LogLevel = logLevel,
                Message = message
            };
            _logRepository.AddLogDb(log);
        }
    }
}
