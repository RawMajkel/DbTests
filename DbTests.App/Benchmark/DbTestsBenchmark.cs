using BenchmarkDotNet.Attributes;
using DbTests.Services;

namespace DbTests.App.Benchmark
{
    public class DbTestsBenchmark
    {
        private readonly ITestService _testService;

        public DbTestsBenchmark()
        {
            _testService = new TestService();
        }

        [Benchmark(Description = "EF")]
        public void EF() => _testService.EFTest();

        [Benchmark(Description = "RawEF")]
        public void RawEF() => _testService.RawEFTest();

        [Benchmark(Description = "ADO.NET")]
        public void Ado() => _testService.AdoTest();

        [Benchmark(Description = "Dapper")]
        public void Dapper() => _testService.DapperTest();

        [Benchmark(Description = "RawSQL")]
        public void RawSQL() => _testService.RawSQLTest();
    }
}
