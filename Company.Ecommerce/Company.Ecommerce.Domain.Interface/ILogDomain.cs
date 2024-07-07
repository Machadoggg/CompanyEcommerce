using Company.Ecommerce.Domain.Entity;

namespace Company.Ecommerce.Domain.Interface
{
    public interface ILogDomain
    {
        void AddLogDb(Log log);
    }
}
