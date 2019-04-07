using InfluxDb.Helper;
using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class InfluxDbCacheServiceCollectionExtensions
    {
        public static IServiceCollection AddInfluxCache(this IServiceCollection services, InfluxDbConfiguration configuration)
        {
            if (services == null)
                throw new ArgumentNullException(nameof(services));

            if (configuration == null)
                throw new ArgumentNullException(nameof(InfluxDbConfiguration));

            services.AddSingleton<IInfluxDbConfiguration>(new InfluxDbConfiguration
            {
                Host = configuration.Host,
               Port = configuration.Port,
               User = configuration.User,
               Password = configuration.Password
            });
            return services;
        }
    }
}
