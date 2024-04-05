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


        #region Methods Syncronous

        public bool Insert(Customers customers)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "CustomersInsert";
                var parameters = new DynamicParameters();

                parameters.Add("CustomerId", customers.CustomerId);
                parameters.Add("CompanyName", customers.CompanyName);
                parameters.Add("ContactName", customers.ContactName);
                parameters.Add("ContactTitle", customers.ContactTitle);
                parameters.Add("Address", customers.Address);
                parameters.Add("City", customers.City);
                parameters.Add("Region", customers.Region);
                parameters.Add("PostalCode", customers.PostalCode);
                parameters.Add("Country", customers.Country);
                parameters.Add("Phone", customers.Phone);
                parameters.Add("Fax", customers.Fax);

                var result = connection.Execute(query, param: parameters, commandType: CommandType.StoredProcedure);
                return result > 0;
            }
        }

        public bool Update(Customers customers)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "CustomersUpdate";
                var parameters = new DynamicParameters();

                parameters.Add("CustomerId", customers.CustomerId);
                parameters.Add("CompanyName", customers.CompanyName);
                parameters.Add("ContactName", customers.ContactName);
                parameters.Add("ContactTitle", customers.ContactTitle);
                parameters.Add("Address", customers.Address);
                parameters.Add("City", customers.City);
                parameters.Add("Region", customers.Region);
                parameters.Add("PostalCode", customers.PostalCode);
                parameters.Add("Country", customers.Country);
                parameters.Add("Phone", customers.Phone);
                parameters.Add("Fax", customers.Fax);

                var result = connection.Execute(query, param: parameters, commandType: CommandType.StoredProcedure);
                return result > 0;
            }
        }

        public bool Delete(string customerId)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "CustomersDelete";
                var parameters = new DynamicParameters();

                parameters.Add("CustomerId", customerId);

                var result = connection.Execute(query, param: parameters, commandType: CommandType.StoredProcedure);
                return result > 0;
            }
        }

        public Customers Get(string customerId)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "CustomersGEtByID";
                var parameters = new DynamicParameters();
                parameters.Add("CustomerId", customerId);

                var customer = connection.QuerySingle<Customers>(query, param: parameters, commandType: CommandType.StoredProcedure);
                return customer;
            }
        }


        #endregion
    }
}
