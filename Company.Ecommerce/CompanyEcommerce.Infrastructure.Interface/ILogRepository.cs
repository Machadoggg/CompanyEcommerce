using Company.Ecommerce.Domain.Entity;

namespace Company.Ecommerce.Infrastructure.Interface
{
    public interface ILogRepository
    {
        Log AddLogDb(Log log);
    }
}
