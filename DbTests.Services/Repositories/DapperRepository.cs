using DbTests.Services.Model;
using Microsoft.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using Dapper;
using System.Configuration;

namespace DbTests.Services.Repositories
{
    public class DapperRepository
    {
        public DapperRepository()
        {
        }

        public IEnumerable<OrderDetails> GetAllFromOrderDetails()
        {
            using var connection = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);
            return connection.Query<OrderDetails>("SELECT * FROM dbo.[Order Details]").ToList();
        }
    }
}
