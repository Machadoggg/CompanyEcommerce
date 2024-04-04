using System;
using Company.Ecommerce.Transversal.Common;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using System.Data;


namespace CompanyEcommerce.Infrastructure.Data
{
    public class ConnectionFactory : IConnectionFactory
    {
        private readonly IConfiguration _configuration;

        public ConnectionFactory(IConfiguration configuration) 
        {
            _configuration = configuration;
        }
    }
}
