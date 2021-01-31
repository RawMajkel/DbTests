using DbTests.Services.Model;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace DbTests.Services.Repositories
{
    public class RawSQLRepository
    {
        public IEnumerable<OrderDetails> GetAllFromOrderDetails()
        {
            using var context = new DbTestsContext();
            return context.OrderDetails.FromSqlRaw("SELECT * FROM dbo.[Order Details]").ToList();
        }
    }
}
