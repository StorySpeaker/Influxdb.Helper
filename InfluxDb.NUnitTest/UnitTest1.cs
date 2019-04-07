using InfluxDb.Helper;
using InfluxDb.NUnitTest;
using NUnit.Framework;
using System.Threading.Tasks;

namespace Tests
{
    public class Tests
    {
        public ILogsRepository LogsRepository { get; set; }

        public Tests(ILogsRepository logsRepository)
        {
            LogsRepository = logsRepository;
        }

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public async Task  Test1()
        {
            await LogsRepository.GetAsync("asdasd");
            Assert.Pass();
        }
    }
}