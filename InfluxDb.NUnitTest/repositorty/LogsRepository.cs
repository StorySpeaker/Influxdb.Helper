using InfluxDb.Helper;
using System;
using System.Collections.Generic;
using System.Text;

namespace InfluxDb.NUnitTest.repositorty
{
    public class LogsRepository : InfluxDbCache<LogInfo, string>, ILogsRepository
    {
        public LogsRepository(IInfluxDbConfiguration configuration) : base(configuration)
        {

        }

        protected override string DbName
        {
            get { return "LogInfo"; }
        }


    }
}
