using System;
using System.Threading.Tasks;
using ecommerce_apple.Repositories;
using Microsoft.AspNetCore.Mvc;
using MongoDBAPI.Models;

namespace ecommerce_apple.Controllers.Products
{
    [ApiController]
    [Route("api/[controller]")]
    public class AppleProductsController : ControllerBase
    {
        private readonly IProductCollection db;

        public AppleProductsController(IConfiguration configuration)
        {
            db = new ProductCollection(configuration);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProductsFromAllCollections()
        {
            try
            {
                var allProducts = await db.GetAllProductsFromAllCollections();
                return Ok(allProducts);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error 500: Internal server error {ex.Message}");
            }
        }

        [HttpGet("{collectionName}")]
        public async Task<IActionResult> GetAllProductsByCollectionName(string collectionName)
        {
            try
            {
                var products = await db.GetAllProductsByCollectionName(collectionName);

                if (products == null || !products.Any())
                {
                    return NotFound($"Collection with name '{collectionName}' not found");
                }

                return Ok(products);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error 500: Internal server error {ex.Message}");
            }
        }

        [HttpGet("{collectionName}/{id}")]
        public async Task<IActionResult> GetProductsByCollectionAndId(string collectionName, string id)
        {
            try
            {
                var product = await db.GetProductsByCollectionAndId(collectionName, id);

                if (product == null)
                {
                    return NotFound($"Prodcut with ID {id} not found");
                }

                return Ok(product);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error 500: Internal server error {ex.Message}");
            }
        }

        [HttpPost("{collectionName}")]
        public async Task<IActionResult> CreateProduct(string collectionName, [FromBody] ProductsModel product)
        {
            try
            {
                if (product == null)
                {
                    return BadRequest();
                }

                if (string.IsNullOrEmpty(product.Model))
                {
                    return BadRequest("Model is required");
                }

                await db.InsertProduct(collectionName, product);
                return Created("Create", true);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error 500: Internal server error {ex.Message}");
            }
        }

        [HttpPut("{collectionName}/{id}")]
        public async Task<IActionResult> UpdateProduct(string collectionName, [FromBody] ProductsModel product, string id)
        {
            try
            {
                if (product == null)
                {
                    return BadRequest();
                }

                product.Id = new MongoDB.Bson.ObjectId(id);
                await db.UpdateProduct(collectionName, product);

                return Created("Update", true);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error 500: Internal server error {ex.Message}");
            }
        }

        [HttpDelete("{collectionName}/{id}")]
        public async Task<IActionResult> DeleteProduct(string collectionName, string id)
        {
            try
            {
                await db.DeleteProduct(collectionName, id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error 500: Internal server error {ex.Message}");
            }
        }
    }
}
