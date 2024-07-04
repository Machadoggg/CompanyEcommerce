using Company.Ecommerce.Domain.Entity;
using Company.Ecommerce.Domain.Interface;
using Company.Ecommerce.Infrastructure.Interface;

namespace Company.Ecommerce.Domain.Core
{
    public class UsersDomain : IUsersDomain
    {
        private readonly IUsersRepository _usersRepository;

        public UsersDomain(IUsersRepository usersRepository)
        {
            _usersRepository = usersRepository;
        }

        public Users Authenticate(string username, string password)
        {
            return _usersRepository.Authenticate(username, password);
        }
    }
}
