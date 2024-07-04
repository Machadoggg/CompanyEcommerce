using Company.Ecommerce.Domain.Entity;

namespace Company.Ecommerce.Domain.Interface
{
    public interface IUsersDomain
    {
        Users Authenticate(string username, string password);
    }
}
