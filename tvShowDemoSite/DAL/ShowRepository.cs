using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;
using tvShowDemoSite.Models;

/* TODO: Add safety to this class' interactions/behaviours.
Currently we will not know if something went wrong when using this class,
unless the underlining driver throws an exception.

Need to find out how MongoDB/the C# driver, handles database operation errors/results.
C# driver docs doesn't seem to note what exceptions get thrown but,
this might be intentional, 
if DB operation errors/results are indicated/handled differently.
Possible that errors are done via WriteConcern, WriteConcernError, etc.
So, look into write concern, then add safeties here.
*/

namespace tvShowDemoSite.DAL
{
    /// <summary>
    /// Repository for ShowModel.
    /// </summary>
    class ShowRepository : MongoDAL
    {
        protected IMongoCollection<ShowModel> collection;
        
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="collectionName">Optional. Advanced use only. Name of the MongoDB collection to use.</param>
        public ShowRepository(string collectionName = "Show") : base()
        {
            collection = database.GetCollection<ShowModel>(collectionName);
        }

        public void Insert(ShowModel show)
        {
            collection.InsertOne(show);
        }
        // TODO: Consider converting this function into an index accessor. Repo[string]
        public ShowModel Get(string id)
        {
            return collection.AsQueryable().First(x => x.Id == id);
        }

        public List<ShowModel> Find(Expression<Func<ShowModel, bool>> predicate, int count = 10)
        {
            // TODO: Consider applying a max value cap for count argument.
            return collection.AsQueryable().Where(predicate).Take(count).ToList();
        }

        public void Replace(ShowModel show)
        {
            collection.ReplaceOne(x => x.Id == show.Id, show);
        }

        public void Delete(string id)
        {
            collection.DeleteOne(x => x.Id == id);
        }
    }
}
