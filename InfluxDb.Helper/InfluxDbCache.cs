using AdysTech.InfluxDB.Client.Net;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InfluxDb.Helper
{
    public abstract class InfluxDbCache<InfluxDbBase, Entity> : IInfluxDbCache<InfluxDbBase, Entity>
    {
        //声明InfluxDbClient
        protected InfluxDBClient InfluxDBConnection;

        protected abstract string DbName { get; }

        public InfluxDbCache(IInfluxDbConfiguration configuration)
        {
            //连接InfluxDb的API地址、账号、密码
            var infuxUrl = $"http://{configuration.Host}:{configuration.Port}/";
            var infuxUser = $"{configuration.User}";
            var infuxPwd = $"{configuration.Password}";

            //创建InfluxDbClient实例
            InfluxDBConnection = new InfluxDBClient(infuxUrl, infuxUser, infuxPwd);
        }

        public async Task<InfluxDbBase> GetAsync(Entity entity)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Querying all DB names
        /// </summary>
        /// <returns></returns>
        public async Task<List<string>> QueryAllDBNames()
        {
            return await InfluxDBConnection.GetInfluxDBNamesAsync();
        }

        /// <summary>
        /// Create new Databases
        /// </summary>
        /// <param name="dbname"></param>
        /// <returns></returns>
        public async Task<bool> CreateNewDatabase(string dbname)
        {
            return await InfluxDBConnection.CreateDatabaseAsync(dbname);
        }
    }
}
