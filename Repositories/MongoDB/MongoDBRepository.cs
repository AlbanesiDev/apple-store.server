using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using MongoDB.Bson;
using MongoDB.Driver;

namespace ecommerce_apple.Repositories
{
    /// <summary>
    /// MongoDBRepository class responsible for connecting to MongoDB and providing access to collections.
    /// </summary>
    public class MongoDBRepository
    {
        private readonly IConfiguration _configuration;
        public MongoClient client;
        public IMongoDatabase db;

        // List to store collection names
        public List<string> CollectionNames { get; private set; } = [];

        /// <summary>
        /// Initializes a new instance of the MongoDBRepository class.
        /// </summary>
        /// <param name="configuration">Application configuration.</param>
        public MongoDBRepository(IConfiguration configuration)
        {
            _configuration = configuration;

            // Get MongoDB connection string from configuration
            string password = _configuration["MongoDB:ConnectionString"] ?? "";

            if (string.IsNullOrEmpty(password))
            {
                throw new Exception("Error 404: MongoDB password not found in configuration.");
            }

            // Create MongoClient using the connection string
            client = new MongoClient(password);

            // Get the MongoDB database
            db = client.GetDatabase("apple-store");

            // Initialize the collection names
            InitializeCollectionNames();
        }

        /// <summary>
        /// Initializes the CollectionNames property with the names of all collections in the database.
        /// </summary>
        private void InitializeCollectionNames()
        {
            var filter = new BsonDocument();
            var options = new ListCollectionNamesOptions { Filter = filter };

            // Use ListCollectionNames to get the names of all collections in the database
            using (var cursor = db.ListCollectionNames(options))
            {
                CollectionNames = cursor.ToList();
            }
        }
    }
}
