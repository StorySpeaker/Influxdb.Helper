using System;
using System.Collections.Generic;
using System.Text;

namespace InfluxDb.Helper
{
    public interface IInfluxDbConfiguration
    {
        string Host { get; set; }

        string Port { get; set; }

        string User { get; set; }

        string Password { get; set; }
    }
}
