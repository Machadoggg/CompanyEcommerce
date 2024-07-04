using Company.Ecommerce.Application.DTO;
using Company.Ecommerce.Transversal.Common;

namespace Company.Ecommerce.Application.Interface
{
    public interface IUsersApplication
    {
        Response<UsersDto> Authenticate(string username, string password);
    }
}
