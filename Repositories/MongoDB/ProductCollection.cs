using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDBAPI.Models;

namespace ecommerce_apple.Repositories
{
    public class ProductCollection : IProductCollection
    {
        internal MongoDBRepository _repository;
        private IMongoCollection<ProductsModel> Collection;

        public ProductCollection(IConfiguration configuration)
        {
            _repository = new MongoDBRepository(configuration);
            Collection = _repository.db.GetCollection<ProductsModel>("Products");
        }

        public async Task<List<ProductsModel>> GetAllProducts()
        {
            return await Collection.FindAsync(new BsonDocument()).Result.ToListAsync();
        }

        public async Task<ProductsModel> GetProductsById(string id)
        {
            return await Collection.FindAsync(
                new BsonDocument { { "_id", new ObjectId(id) } }).Result.
                FirstAsync();
        }

        public async Task InsertProduct(ProductsModel product)
        {
            await Collection.InsertOneAsync(product);
        }

        public async Task UpdateProduct(ProductsModel product)
        {
            var filter = Builders<ProductsModel>.Filter.Eq(s => s.Id, product.Id);

            await Collection.ReplaceOneAsync(filter, product);
        }
        
        public async Task DeleteProduct(string id)
        {
            var filter = Builders<ProductsModel>.Filter.Eq(s => s.Id, new ObjectId(id));
            await Collection.DeleteOneAsync(filter);
        }
    }
}