namespace DbTests.Services
{
    public interface ITestService
    {
        void AdoTest();
        void DapperTest();
        void EFTest();
        void RawEFTest();
        void RawSQLTest();
    }
}
