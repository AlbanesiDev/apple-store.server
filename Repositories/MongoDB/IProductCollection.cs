using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Driver;
using MongoDBAPI.Models;

namespace ecommerce_apple.Repositories
{
    /// <summary>
    /// Interface for accessing and managing products in different collections in MongoDB.
    /// </summary>
    public interface IProductCollection
    {
        /// <summary>
        /// Gets all the names of the collections.
        /// </summary>
        /// <returns>A list of names of all collections.</returns>
        Task<List<string>> GetCollectionNames();

        /// <summary>
        /// Gets all products from all collections.
        /// </summary>
        /// <returns>A list of products from all collections.</returns>
        Task<List<ProductsModel>> GetAllProductsFromAllCollections();

        /// <summary>
        /// Gets all products in a specific collection.
        /// </summary>
        /// <param name="collectionName">The name of the collection.</param>
        /// <returns>A list of products in the specified collection.</returns>
        Task<List<ProductsModel>> GetAllProductsByCollectionName(string collectionName);

        /// <summary>
        /// Gets a product by collection name and ID.
        /// </summary>
        /// <param name="collectionName">The name of the collection.</param>
        /// <param name="id">The ID of the product.</param>
        /// <returns>The product with the specified ID in the specified collection.</returns>
        Task<ProductsModel> GetProductsByCollectionAndId(string collectionName, string id);

        /// <summary>
        /// Inserts a new product into the specified collection.
        /// </summary>
        /// <param name="collectionName">The name of the collection.</param>
        /// <param name="product">The product to insert.</param>
        Task InsertProduct(string collectionName, ProductsModel product);

        /// <summary>
        /// Updates an existing product in the specified collection.
        /// </summary>
        /// <param name="collectionName">The name of the collection.</param>
        /// <param name="product">The updated product.</param>
        Task UpdateProduct(string collectionName, ProductsModel product);

        /// <summary>
        /// Deletes a product by ID from the specified collection.
        /// </summary>
        /// <param name="collectionName">The name of the collection.</param>
        /// <param name="id">The ID of the product to delete.</param>
        Task DeleteProduct(string collectionName, string id);
    }
}