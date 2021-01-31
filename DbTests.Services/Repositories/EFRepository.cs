using DbTests.Services.Model;
using System.Collections.Generic;
using System.Linq;

namespace DbTests.Services.Repositories
{
    public class EFRepository
    {
        private readonly DbTestsContext _context;

        public EFRepository(DbTestsContext context)
        {
            _context = context;
        }

        public IEnumerable<OrderDetails> GetAllFromOrderDetails()
            => _context.OrderDetails.ToList();
    }
}
