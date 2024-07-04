using Company.Ecommerce.Domain.Entity;

namespace Company.Ecommerce.Infrastructure.Interface
{
    public interface IUsersRepository
    {
        Users Authhenticate(string username, string password);
    }
}
