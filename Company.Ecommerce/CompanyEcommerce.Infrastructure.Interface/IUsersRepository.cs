using Company.Ecommerce.Domain.Entity;

namespace Company.Ecommerce.Infrastructure.Interface
{
    public interface IUsersRepository
    {
        Users Authenticate(string username, string password);
    }
}
