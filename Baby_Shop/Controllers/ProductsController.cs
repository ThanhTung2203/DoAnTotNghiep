using Baby_Shop.Interface;
using Baby_Shop.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Baby_Shop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepository _productRepo;
        
        public ProductsController(IProductRepository repo)
        {
            _productRepo = repo;
            
        }
        [HttpGet]
        public async Task<IActionResult> GettAllProduct()
        {
            try
            {
                return Ok( await _productRepo.getAllProductAsync());
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpGet("id")]
        public async Task<IActionResult>GetProductById(int id)
        {
            var product = await _productRepo.getProductsAsync(id);
            var existingProduct = await _productRepo.getProductsAsync(product.Id);

            if (existingProduct != null)
            {
                return Conflict("A product with the same ID already exists");
            }
            
            return product==null? NotFound():Ok(product);
        }
        [HttpPost]
        public async Task<IActionResult>CreateProduct(Product product)
        {
            try
            {
                var newProductId = await _productRepo.CreateProductAsync(product);
                var products = await _productRepo.getProductsAsync(newProductId);
                return products == null ? NotFound() : Ok(products);
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpPut("{id}")]
        public async Task<IActionResult>updateProduct(int id, Product product)
        {
            try
            {
                await _productRepo.UpdateProductAsync(id, product);
                return Ok();
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult>deleteProduct(int id)
        {
            try
            {
                await _productRepo.DeleteProductAsync(id);
                return Ok();
            }
            catch(Exception ex)
                {
                return StatusCode(500, $"Internal server error :{ex}");
            }
        }
    }

}
