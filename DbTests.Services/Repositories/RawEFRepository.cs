using DbTests.Services.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DbTests.Services.Repositories
{
    public class RawEFRepository
    {
        public IEnumerable<OrderDetails> GetAllFromOrderDetails()
        {
            using var context = new DbTestsContext();
            return CompiledQuery().Invoke(context);
        }

        private Func<DbTestsContext, IEnumerable<OrderDetails>> CompiledQuery()
            => EF.CompileQuery((DbTestsContext context) =>
                context.OrderDetails.ToList());
    }
}
