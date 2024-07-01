using Company.Ecommerce.Application.DTO;
using Company.Ecommerce.Transversal.Common;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Company.Ecommerce.Application.Interface
{
    public interface ICustomerApplication
    {
        #region Methods Synchronous
        Response<bool> Insert(CustomersDto customersDto);
        Response<bool> Update(CustomersDto customersDto);
        Response<bool> Delete(string customerId);

        Response<CustomersDto> Get(string customerId);
        Response<IEnumerable<CustomersDto>> GetAll();
        #endregion


        #region Methods Asynchronous
        Task<Response<bool>> InsertAsync(CustomersDto customersDto);
        Task<Response<bool>> UpdateAsync(CustomersDto customersDto);
        Task<Response<bool>> DeleteAsync(string customerId);

        Task<Response<CustomersDto>> GetAsync(string customerId);
        Task<Response<IEnumerable<CustomersDto>>> GetAllAsync();
        #endregion
    }
}
