using Company.Ecommerce.Domain.Entity;
using Company.Ecommerce.Domain.Interface;
using Company.Ecommerce.Infrastructure.Interface;

namespace Company.Ecommerce.Domain.Core
{
    public class LogDomain : ILogDomain
    {
        //public void AddLogDb(Log log)
        //{
        //    throw new System.NotImplementedException();
        //}
        private readonly ILogRepository _logRepository;

        public LogDomain(ILogRepository logRepository)
        {
            _logRepository = logRepository;
        }

        public bool AddLogDb(Log log)
        {
            return _logRepository.AddLogDb(log);
        }

    }
}
