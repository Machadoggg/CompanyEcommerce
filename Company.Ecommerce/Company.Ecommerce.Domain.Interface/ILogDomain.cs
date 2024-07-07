using Company.Ecommerce.Domain.Entity;

namespace Company.Ecommerce.Domain.Interface
{
    public interface ILogDomain
    {
        bool AddLogDb(Log log);
    }
}
