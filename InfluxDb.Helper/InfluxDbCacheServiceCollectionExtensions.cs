using InfluxDb.Helper;
using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class InfluxDbCacheServiceCollectionExtensions
    {
        public static IServiceCollection AddInfluxCache(this IServiceCollection services, Action<InfluxDbCacheOptions> action)
        {
            if (services == null)
                throw new ArgumentNullException(nameof(services));

            if (action == null)
                throw new ArgumentNullException(nameof(action));

            services.AddOptions();
            services.Configure(action);
            services.Add(ServiceDescriptor.Singleton<IInfluxDbCache, InfluxDbCache>());

            return services;
        }
    }
}
