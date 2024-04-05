using System;
using Company.Ecommerce.Domain.Entity;
using Company.Ecommerce.Infrastructure.Interface;
using Company.Ecommerce.Transversal.Common;
using Dapper;
using System.Data;
using System.Threading.Tasks;

namespace Company.Ecommerce.Infrastructure.Repository
{
    public class CustomersRepository : ICustomersRepository
    {
        private readonly IConnectionFactory _connectionFactory;

        public CustomersRepository(IConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }
    }
}
