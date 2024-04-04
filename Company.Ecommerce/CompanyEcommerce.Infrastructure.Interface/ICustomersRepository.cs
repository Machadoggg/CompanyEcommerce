using System;
using System.Collections.Generic;
using System.Text;
using Company.Ecommerce.Domain.Entity;
using System.Threading.Tasks;

namespace Company.Ecommerce.Infrastructure.Interface
{
    public interface ICustomersRepository
    {
        #region Methods Synchronous
        bool Insert(Customers customer);
        bool Update(Customers customer);
        bool Delete(string customerId);

        Customers Get(string customerId);
        IEnumerable<Customers> GetAll();
        #endregion


        #region Methods Asynchronous
        Task<bool> InsertAsync(Customers customer);
        Task<bool> UpdateAsync(Customers customer);
        Task<bool> DeleteAsync(string customerId);

        Task<Customers> GetAsync(string customerId);
        Task<IEnumerable<Customers>> GetAllAsync();
        #endregion

    }
}
