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
        /// <param name="collectionName">Optional. Advanced use only. Name of the MongoDB collection to use. Throws ArgumentNullException on null.</param>
        public ShowRepository(string collectionName = "Show") : base()
        {
            if (collectionName == null)
                throw new ArgumentNullException("collectionName");

            collection = database.GetCollection<ShowModel>(collectionName);
        }

        /// <summary>
        /// Insert new show, 
        /// </summary>
        /// <param name="show">The populated data model to insert. Throws ArgumentNullException on null.</param>
        public void Insert(ShowModel show)
        {
            if (show == null)
                throw new ArgumentNullException("show");

            collection.InsertOne(show);
        }

        // TODO: Consider converting this function into an index accessor. Repo[string]
        /// <summary>
        /// Returns the show with the given Id, or null if not found.
        /// Looks for an exact match.
        /// </summary>
        /// <param name="id">The Id of the show to find. Throws ArgumentNullException on null.</param>
        /// <returns>The show, or null if not found.</returns>
        public ShowModel Get(string id)
        {
            if (id == null)
                throw new ArgumentNullException("id");
            
            try
            {
                return collection.AsQueryable().First(x => x.Id == id);
            }
            catch (InvalidOperationException e)
            {
                return null;
            }
        }

        /// <summary>
        /// Performs a search with the given predicate. Returns result as a list (empty list when no items found).
        /// </summary>
        /// <param name="predicate">The predicate to use when performing the search. Throws ArgumentNullException on null.</param>
        /// <param name="count">Max number of items to return. Throws ArgumentOutOfRangeException when value is less than one.</param>
        /// <returns>A list of shows matched by the predicate.</returns>
        public List<ShowModel> Find(Expression<Func<ShowModel, bool>> predicate, int count = 10)
        {
            if (count < 1)
                throw new ArgumentOutOfRangeException("count", count, "Value cannot be less than 1.");
            if (predicate == null)
                throw new ArgumentNullException("predicate");
            // TODO: Consider applying a max value cap for count argument.

            return collection.AsQueryable().Where(predicate).Take(count).ToList();
        }

        /// <summary>
        /// Replace an existing show with the given show.
        /// The show to replace is matched using the Id in the given show.
        /// </summary>
        /// <param name="show">The show with the Id and new data to replace.</param>
        public void Replace(ShowModel show)
        {
            collection.ReplaceOne(x => x.Id == show.Id, show);
        }

        /// <summary>
        /// Deletes an existing show, using Id.
        /// </summary>
        /// <param name="id">The Id of the show to delete. Throws ArgumentNullException on null.</param>
        public void Delete(string id)
        {
            if (id == null)
                throw new ArgumentNullException("id");

            collection.DeleteOne(x => x.Id == id);
        }
    }
}
