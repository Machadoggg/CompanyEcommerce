using AutoMapper;
using Company.Ecommerce.Application.DTO;
using Company.Ecommerce.Application.Interface;
using Company.Ecommerce.Domain.Interface;
using Company.Ecommerce.Transversal.Common;
using System;

namespace Company.Ecommerce.Application.Main
{
    public class UsersApplication : IUsersApplication
    {
        private readonly IUsersDomain _usersDomain;
        private readonly IMapper _mapper;
        private readonly IAppLogger<CustomersApplication> _logger;

        public UsersApplication(IUsersDomain usersDomain, IMapper mapper, IAppLogger<CustomersApplication> logger)
        {
            _usersDomain = usersDomain;
            _mapper = mapper;
            _logger = logger;
        }

        public Response<UsersDto> Authenticate(string username, string password)
        {
            var response = new Response<UsersDto>();

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                response.Message = "Parámetros no pueden ser vacios.";
                _logger.LogWarning("Parámetros no pueden ser vacios.");
                return response;
            }

            try
            {
                var user = _usersDomain.Authenticate(username, password);
                response.Data = _mapper.Map<UsersDto>(user);
                response.IsSuccess = true;
                response.Message = "Authenticación exitosa!!!";
                _logger.LogInformation("Authenticación exitosa!!!");
            }
            catch (InvalidOperationException)
            {
                response.IsSuccess = true;
                response.Message = "Usuario no existe";
                _logger.LogWarning("Usuario no existe");
            }
            catch (Exception e)
            {
                response.Message = e.Message;
                _logger.LogError(e.Message);
            }
            return response;
        }
    }
}
