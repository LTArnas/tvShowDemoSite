using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using MongoDB.Bson;
using MongoDB.Driver;

namespace tvShowDemoSite.DAL
{
    /// <summary>
    /// Root base class for MongoDB data access layer classes.
    /// </summary>
    abstract class MongoDAL
    {
        protected IMongoClient client;
        protected IMongoDatabase database;
        
        /// <summary>
        /// Convenience constructor. Chains constructor with arguments.
        /// Attempts to use ConfigurationManager for required arguments.
        /// This means Web.config must have the correct entries.
        /// </summary>
        public MongoDAL() : 
            this(ConfigurationManager.ConnectionStrings["mongodb"]?.ConnectionString, 
                ConfigurationManager.AppSettings["mongodb_databaseName"])
        { }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="connectionString">Valid MongoDB connection string URI.</param>
        /// <param name="databaseName">The database to use (by name).</param>
        public MongoDAL(string connectionString, string databaseName)
        {
            client = new MongoClient(connectionString);
            database = client.GetDatabase(databaseName);
        }

        /// <summary>
        /// Generates a new ID, that is valid for MongoDB.
        /// </summary>
        /// <returns>The ID.</returns>
        public static string GenerateId()
        {
            return ObjectId.GenerateNewId().ToString();
        }
    }
}
