using Microsoft.Extensions.Configuration;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MongoDBSampleAPI.Repository
{
    public class MongoDBRepository : IMongoDBRepository
    {
        private readonly MongoClient _mongoClient;
        private readonly IMongoDatabase _database;
        private readonly IConfiguration _configuration;
        private const string DATABASE_NAME = "mongodb_POC";
        private const string COLLECTION_NAME = "ContentModel";

        public MongoDBRepository(IConfiguration configuration)
        {
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
            _mongoClient = new MongoClient(_configuration.GetSection("ConnectionString")?.Value);
            _database = _mongoClient.GetDatabase(DATABASE_NAME);
        }

        public IEnumerable<object> GetAll()
        {
            var collection = _database.GetCollection<BsonDocument>(COLLECTION_NAME);

            return collection.Find(new BsonDocument()).ToList();
        }
    }
}
