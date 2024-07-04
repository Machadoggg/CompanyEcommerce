using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Company.Ecommerce.Application.DTO;
using Company.Ecommerce.Application.Interface;
using Microsoft.AspNetCore.Authorization;

namespace Company.Ecommerce.Services.WebApi.Controllers
{
    [Authorize]
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
        [ActionName("Insert")]
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
        [ActionName("Update")]
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
        [ActionName("Delete")]
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
        [ActionName("Get")]
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
        [ActionName("GetAll")]
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
        [ActionName("InsertAsync")]
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
        [ActionName("UpdateAsync")]
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
        [ActionName("DeleteAsync")]
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
        [ActionName("GetAsync")]
        public async Task<IActionResult> GetAsync(string CustomerId)
        {
            if (string.IsNullOrEmpty(CustomerId))
                return BadRequest();

            var response = await _customerApplication.GetAsync(CustomerId);
            if (response.IsSuccess)
                return Ok(response);

            return BadRequest(response.Message);
        }

        [HttpGet]
        [ActionName("GetAllAsync")]
        public async Task<IActionResult> GetAllAsync()
        {
            var response = await _customerApplication.GetAllAsync();
            if (response.IsSuccess)
                return Ok(response);

            return BadRequest(response.Message);
        }
        #endregion

    }
}
