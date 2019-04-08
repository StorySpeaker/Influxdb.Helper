using AdysTech.InfluxDB.Client.Net;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace InfluxDb.Helper
{
    public interface IInfluxDbCache<InfluxDbBase, Entity>
    {

        /// <summary>
        /// Insert into InfluxDatabase
        /// </summary>
        /// <param name="dbBase"></param>
        /// <returns></returns>
        Task InsertAsync(InfluxDbBase dbBase);

        /// <summary>
        /// Querying all DB names
        /// </summary>
        /// <returns></returns>
        Task<List<string>> QueryAllDBNames();

        /// <summary>
        /// Create new Databases
        /// </summary>
        /// <param name="dbname"></param>
        Task<bool> CreateNewDatabase(string dbname);

        /// <summary>
        /// Get InfluxData
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task<InfluxDbBase> GetAsync(Entity entity);

        /// <summary>
        /// Get All List
        /// </summary>
        /// <returns></returns>
        Task<List<IInfluxSeries>> GetAllListAsync();
    }
}
