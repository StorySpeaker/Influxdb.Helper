using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace InfluxDb.Helper
{
    public interface IInfluxDbCache<InfluxDbBase, Entity>
    {
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
    }
}
