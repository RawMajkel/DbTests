using DbTests.Services.Repositories;

namespace DbTests.Services
{
    public class TestService : ITestService
    {
        public TestService()
        {

        }

        public void EFTest() => new EFRepository(new DbTestsContext()).GetAllFromOrderDetails();
        public void RawEFTest() => new RawEFRepository().GetAllFromOrderDetails();
        public void AdoTest() => new AdoRepository().GetAllFromOrderDetails();
        public void DapperTest() => new DapperRepository().GetAllFromOrderDetails();
        public void RawSQLTest() => new RawSQLRepository().GetAllFromOrderDetails();
    }
}
