using Company.Ecommerce.Domain.Entity;
using Company.Ecommerce.Infrastructure.Interface;
using Company.Ecommerce.Transversal.Common;
using Dapper;
using System.Collections.Generic;
using System.Data;

namespace Company.Ecommerce.Infrastructure.Repository
{
    public class LogRepository : ILogRepository
    {
        private readonly IConnectionFactory _connectionFactory;

        public LogRepository(IConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public bool AddLogDb(Log log)
        {

            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "LogsInsert";
                var parameters = new DynamicParameters();

                parameters.Add("LogLevel", log.LogLevel);
                parameters.Add("Message", log.Message);

                var result = connection.Execute(query, param: parameters, commandType: CommandType.StoredProcedure);
                return result > 0;
            }

        }

    }
}
