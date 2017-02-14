using System;
using System.Collections.Generic;
using System.Linq;
using MongoDB.Driver;
using System.Text;
using System.Threading.Tasks;

using ES6.Readers.Contracts;
using ES6.Models.Features;
using ES6.Models.Platforms;

namespace ES6.Readers
{
    public class MongoReader : IMongoReader
    {
        private const string ConnectionString = "mongodb://localhost";
        private const string DatabaseName = "ES6-data";
        private const string FeaturesCollectionName = "Features";
        private const string PlatformsCollectionName = "Platforms";

        public MongoReader()
        {
        }

        public IEnumerable<Category> ReadMongoFeatures()
        {
            var mongoDb = this.GetMongoDb();
            var collection = mongoDb.GetCollection<Category>(FeaturesCollectionName);

            var result = collection.Find(f => true).ToList();

            return result;
        }

        public IEnumerable<PlatformType> ReadMongoPlatforms()
        {
            var mongoDb = this.GetMongoDb();
            var collection = mongoDb.GetCollection<PlatformType>(PlatformsCollectionName);

            var result = collection.Find(f => true).ToList();

            return result;
        }

        private IMongoDatabase GetMongoDb()
        {
            var mongoDbClient = new MongoClient(ConnectionString);
            return mongoDbClient.GetDatabase(DatabaseName);
        }
    }
}
