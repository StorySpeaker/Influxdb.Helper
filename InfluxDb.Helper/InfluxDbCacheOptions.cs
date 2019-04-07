using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Extensions.DependencyInjection
{
    public class InfluxDbCacheOptions : IOptions<InfluxDbCacheOptions>
    {
        public string Host { get; set; }

        public string Port { get; set; }

        public string User { get; set; }

        public string Password { get; set; }

        InfluxDbCacheOptions IOptions<InfluxDbCacheOptions>.Value
        {
            get { return this; }
        }
    }
}
