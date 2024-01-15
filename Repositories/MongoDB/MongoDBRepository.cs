using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace ecommerce_apple.Repositories
{
    
    public class MongoDBRepository
    {

        private IConfiguration _configuration;

        public MongoClient client;

        public IMongoDatabase db;

        public MongoDBRepository(IConfiguration configuration)
        {

            _configuration = configuration;

            string password = _configuration["MongoDB:ConnectionString"] ?? "";

            if (string.IsNullOrEmpty(password))
            {
                throw new Exception("Error 404: MongoDB password not found in configuration.");
            }
            client = new MongoClient(password);
            db = client.GetDatabase("apple-store");
        }
    }
}