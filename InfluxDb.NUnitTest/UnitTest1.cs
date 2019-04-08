using InfluxDb.Helper;
using InfluxDb.NUnitTest;
using Microsoft.Extensions.DependencyInjection;
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
        public void Setup(IServiceCollection services)
        {
            services.AddInfluxCache(new InfluxDbConfiguration()
            {
                Host = "118.25.19.51",
                Port = "8086",
                User = "user",
                Password = "admin"
            });
        }

        [Test]
        public async Task Test1()
        {
            await LogsRepository.GetAsync("asdasd");
            Assert.Pass();
        }
    }
}