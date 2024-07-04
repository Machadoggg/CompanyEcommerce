using Company.Ecommerce.Application.DTO;
using Company.Ecommerce.Application.Interface;
using Company.Ecommerce.Services.WebApi.Helpers;
using Company.Ecommerce.Transversal.Common;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace Company.Ecommerce.Services.WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUsersApplication _usersApplication;
        private readonly AppSettings _appSettings;

        public UsersController(IUsersApplication usersApplication, IOptions<AppSettings> appSettings)
        {
            _usersApplication = usersApplication;
            _appSettings = appSettings.Value;
        }

        [HttpPost]
        public IActionResult Authenticate([FromBody]UsersDto usersDto) 
        {
           var response = _usersApplication.Authenticate(usersDto.UsrName, usersDto.Password);

            if (response.IsSuccess)
            {
                if (response.Data != null)
                {

                }
                else
                    return NotFound();
            }
        }

       
    }
}
