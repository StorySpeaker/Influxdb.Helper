using InfluxDb.Helper;
using System;
using System.Collections.Generic;
using System.Text;

namespace InfluxDb.NUnitTest
{
    public interface ILogsRepository : IInfluxDbCache<LogInfo, string>
    {

    }
}
