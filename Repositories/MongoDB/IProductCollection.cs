using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Driver;
using MongoDBAPI.Models;

namespace ecommerce_apple.Repositories
{
    public interface IProductCollection
    {
        Task UpdateProduct(ProductsModel product);
        Task InsertProduct(ProductsModel product);
        Task DeleteProduct(string id);
        Task<List<ProductsModel>> GetAllProducts();
        Task<ProductsModel> GetProductsById(string id);
    }
}