using AdysTech.InfluxDB.Client.Net;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InfluxDb.Helper
{
    public abstract class InfluxDbCache<InfluxDbBase, Entity> : IInfluxDbCache<InfluxDbBase, Entity>
    {
        //声明InfluxDbClient
        protected InfluxDBClient InfluxDBConnection;

        private static readonly string DbName = nameof(InfluxDbBase);

        protected abstract string TableName { get; set; }

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
            //var result = await InfluxDBConnection.QueryMultiSeriesAsync(DbName,);
            throw new Exception();
        }

        public async Task InsertAsync(InfluxDbBase dbBase)
        {
            var valMixed = new InfluxDatapoint<InfluxValueField>();
            valMixed.UtcTimestamp = DateTime.UtcNow;
            valMixed.Tags.Add("Date", DateTime.UtcNow.ToShortDateString());
            valMixed.Tags.Add("Time", DateTime.UtcNow.ToShortTimeString());
            var list = JsonConvert.DeserializeObject<Dictionary<string, string>>(JsonConvert.SerializeObject(dbBase));
            foreach (var item in list)
            {
                valMixed.Fields.Add($"{item.Key}", new InfluxValueField(item.Value));
            }

            var r = await InfluxDBConnection.PostPointAsync(DbName, valMixed);
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

        /// <summary>
        /// Get All List
        /// </summary>
        /// <returns></returns>
        public async Task<List<IInfluxSeries>> GetAllListAsync()
        {
            var list = await InfluxDBConnection.QueryMultiSeriesAsync(DbName, $"select * from {TableName} WHERE 1=1");
            return list.ToList(); ;
        }
    }
}
