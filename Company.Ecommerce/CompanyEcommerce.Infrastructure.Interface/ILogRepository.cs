using Company.Ecommerce.Domain.Entity;

namespace Company.Ecommerce.Infrastructure.Interface
{
    public interface ILogRepository
    {
        bool AddLogDb(Log log);
    }
}
