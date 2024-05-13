using AutoMapper;
using Backend.Data;
using Backend.Dto;
using Backend.Helpers;
using Backend.Interfaces;
using Backend.Models;
using Backend.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        
        public ProductsController(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository=productRepository;
            _mapper = mapper;
        }
        [HttpPost]
        public async Task<IActionResult> AddProductAsync([FromForm]Product product)
        {
            try
            {
                var newProduct = await _productRepository.AddProductAsync(product);
                return Ok(newProduct);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet]
        [Authorize(Roles =ApplicationRole.Admin)]
        public async Task<IActionResult> getAllProductAsync()
        {
            try
            {
                //return Ok(await _productRepository.getAllProductAsync());
                var products = await _productRepository.getAllProductAsync();
                var productDtos = products.Select(p => _mapper.Map<ProductDto>(p));
                return Ok(productDtos);
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> getProductByIdAsync(int id)
        {
           var product=await _productRepository.getProductByIdAsync(id);
            return product==null? NotFound() : Ok(product);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> updateProductAsync(int id, Product product)
        {
            try
            {
                await _productRepository.updateProductAsync(id, product);
                return Ok("Cập nhật thành công!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteProductAsync(int id)
        {
            try
            {
                await _productRepository.DeleteProductAsync(id);
                return Ok("Đã xóa thành công !");
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
