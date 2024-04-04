using System;
using System.Collections.Generic;
using System.Text;
using Company.Ecommerce.Domain.Entity;

namespace Company.Ecommerce.Infrastructure.Interface
{
    public interface ICustomersRepository
    {
        bool Insert(Customers customer);
        bool Update(Customers customer);
        bool Delete(string customerId);
        Customers DeleteAll(string customerId);
        IEnumerable<Customers> GetAll();

    }
}
