using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDBAPI.Models;

namespace ecommerce_apple.Repositories
{
    /// <summary>
    /// Repository for accessing and managing product collections in MongoDB.
    /// </summary>
    public class ProductCollection : IProductCollection
    {
        internal MongoDBRepository _repository;

        /// <summary>
        /// Initializes a new instance of the ProductCollection class.
        /// </summary>
        /// <param name="configuration">Application configuration.</param>
        public ProductCollection(IConfiguration configuration)
        {
            _repository = new MongoDBRepository(configuration);
        }

        //==========================================================================
        // Get the name of collections
        /// <inheritdoc/>
        public async Task<List<string>> GetCollectionNames()
        {
            return await _repository.GetCollectionNames();
        }

        //==========================================================================
        // Get all products from all collections
        /// <inheritdoc/>
        public async Task<List<ProductsModel>> GetAllProductsFromAllCollections()
        {
            var allProducts = new List<ProductsModel>();

            foreach (var collectionName in _repository.CollectionNames)
            {
                var productsInCollection = await GetAllProductsByCollectionName(collectionName);
                allProducts.AddRange(productsInCollection);
            }
            return allProducts;
        }

        //==========================================================================
        // Get all products in a collection
        /// <inheritdoc/>
        public async Task<List<ProductsModel>> GetAllProductsByCollectionName(string collectionName)
        {
            var collection = _repository.db.GetCollection<ProductsModel>(collectionName);
            var filter = Builders<ProductsModel>.Filter.Empty;
            return await collection.Find(filter).ToListAsync();
        }

        //==========================================================================
        // Get products according to collection and id
        /// <inheritdoc/>
        public async Task<ProductsModel> GetProductsByCollectionAndId(string collectionName, string id)
        {
            var collection = _repository.db.GetCollection<ProductsModel>(collectionName);
            var filter = Builders<ProductsModel>.Filter.Eq(s => s.Id, new ObjectId(id));
            return await collection.Find(filter).FirstOrDefaultAsync();
        }

        //==========================================================================
        // Insert product according to collection
        /// <inheritdoc/>
        public async Task InsertProduct(string collectionName, ProductsModel product)
        {
            var collection = _repository.db.GetCollection<ProductsModel>(collectionName);
            await collection.InsertOneAsync(product);
        }

        //==========================================================================
        // Update product according to collection and id
        /// <inheritdoc/>
        public async Task UpdateProduct(string collectionName, ProductsModel product)
        {
            var collection = _repository.db.GetCollection<ProductsModel>(collectionName);
            var filter = Builders<ProductsModel>.Filter.Eq(s => s.Id, product.Id);
            await collection.ReplaceOneAsync(filter, product);
        }

        //==========================================================================
        // Delete product according to collection and id
        /// <inheritdoc/>
        public async Task DeleteProduct(string collectionName, string id)
        {
            var collection = _repository.db.GetCollection<ProductsModel>(collectionName);
            var filter = Builders<ProductsModel>.Filter.Eq(s => s.Id, new ObjectId(id));
            await collection.DeleteOneAsync(filter);
        }
    }
}
