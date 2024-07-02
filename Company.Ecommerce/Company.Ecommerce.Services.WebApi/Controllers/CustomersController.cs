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

        [HttpPut]
        public IActionResult Update([FromBody] CustomersDto customersDto)
        {
            if (customersDto == null)
                return BadRequest();

            var response = _customerApplication.Update(customersDto);
            if (response.IsSuccess)
                return Ok(response);

            return BadRequest(response.Message);
        }

        [HttpDelete("{CustomerId}")]
        public IActionResult Delete(string CustomerId)
        {
            if (string.IsNullOrEmpty(CustomerId))
                return BadRequest();

            var response = _customerApplication.Delete(CustomerId);
            if (response.IsSuccess)
                return Ok(response);

            return BadRequest(response.Message);
        }

        [HttpGet("{CustomerId}")]
        public IActionResult Get(string CustomerId)
        {
            if (string.IsNullOrEmpty(CustomerId))
                return BadRequest();

            var response = _customerApplication.Get(CustomerId);
            if (response.IsSuccess)
                return Ok(response);

            return BadRequest(response.Message);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var response = _customerApplication.GetAll();
            if (response.IsSuccess)
                return Ok(response);

            return BadRequest(response.Message);
        }
        #endregion


        #region "Async methods"
        [HttpPost]
        public async Task<IActionResult> InsertAsync([FromBody] CustomersDto customersDto)
        {
            if (customersDto == null)
                return BadRequest();

            var response = await _customerApplication.InsertAsync(customersDto);
            if (response.IsSuccess)
                return Ok(response);

            return BadRequest(response.Message);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAsync([FromBody] CustomersDto customersDto)
        {
            if (customersDto == null)
                return BadRequest();

            var response = await _customerApplication.UpdateAsync(customersDto);
            if (response.IsSuccess)
                return Ok(response);

            return BadRequest(response.Message);
        }

        [HttpDelete("{CustomerId}")]
        public async Task<IActionResult> DeleteAsync(string CustomerId)
        {
            if (string.IsNullOrEmpty(CustomerId))
                return BadRequest();

            var response = await _customerApplication.DeleteAsync(CustomerId);
            if (response.IsSuccess)
                return Ok(response);

            return BadRequest(response.Message);
        }

        [HttpGet("{CustomerId}")]
        public async Task<IActionResult> GetAsync(string CustomerId)
        {
            if (string.IsNullOrEmpty(CustomerId))
                return BadRequest();

            var response = await _customerApplication.GetAsync(CustomerId);
            if (response.IsSuccess)
                return Ok(response);

            return BadRequest(response.Message);
        }
        #endregion

    }
}
