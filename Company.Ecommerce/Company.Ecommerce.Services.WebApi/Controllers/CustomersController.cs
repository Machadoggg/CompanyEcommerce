using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Company.Ecommerce.Application.DTO;
using Company.Ecommerce.Application.Interface;

namespace Company.Ecommerce.Services.WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CustomersController : Controller
    {
        private readonly ICustomerApplication _customerApplication;

        public CustomersController(ICustomerApplication customerApplication)
        {
            _customerApplication = customerApplication;
        }

        #region "Sync methods"
        [HttpPost]
        public IActionResult Insert([FromBody]CustomersDto customersDto)
        {
            if (customersDto == null)
                return BadRequest();

            var response = _customerApplication.Insert(customersDto);
            if (response.IsSuccess)
            return Ok(response);

            return BadRequest(response.Message);
        }
        #endregion

    }
}
