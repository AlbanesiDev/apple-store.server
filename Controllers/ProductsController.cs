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
        private IProductCollection db;

        public AppleProductsController(IConfiguration configuration)
        {
            db = new ProductCollection(configuration);
        }
        
        [HttpGet]
        public async Task<IActionResult> GetAllProducts()
        {
            try
            {
                var products = await db.GetAllProducts();
                return Ok(products);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error 500: Internal server error {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductsById(string id)
        {
            try
            {
                var product = await db.GetProductsById(id);

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

        [HttpPost]
        public async Task<IActionResult> CreateProduct([FromBody] ProductsModel product)
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

                await db.InsertProduct(product);
                return Created("Create", true);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error 500: Internal server error {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct([FromBody] ProductsModel product, string id)
        {
            try
            {
                if (product == null)
                {
                    return BadRequest();
                }

                product.Id = new MongoDB.Bson.ObjectId(id);
                await db.UpdateProduct(product);

                return Created("Update", true);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error 500: Internal server error {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(string id)
        {
            try
            {
                await db.DeleteProduct(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error 500: Internal server error {ex.Message}");
            }
        }
    }
}
