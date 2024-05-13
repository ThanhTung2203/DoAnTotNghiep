using Backend.Interfaces;
using Backend.Models;
using Backend.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryRepository _categoryRepo;
        public CategoriesController(ICategoryRepository categoryRepo)
        {
            _categoryRepo=categoryRepo;
        }
        [HttpGet]
        public async Task<IEnumerable<Category>> GetAll()
        {
           return await _categoryRepo.GetAllCategoriesAsync();
        }
        [HttpGet("{id}")]
        public async Task<Category> GetCategoryByIdAsync(int id)
        {
            return await _categoryRepo.GetCategoryByIdAsync(id);
        }
        [HttpPost]
        public async Task AddCategory(Category category)
        {
            try
            {
                await _categoryRepo.AddCategoryAsync(category);
            }
            catch(Exception ex)
            {
                 BadRequest(ex.Message);
            }
        }
        [HttpPut]
        public async Task UpdateCategoryAsync(Category category)
        {
            try
            {
                await _categoryRepo.UpdateCategoryAsync(category);
            }
            catch(Exception ex)
            {
                BadRequest(ex.Message);
            }
        }
        [HttpDelete]
        public async Task DeleteCategoryAsync(int id)
        {
            try
            {
                await _categoryRepo.DeleteCategoryAsync(id);
            }
            catch(Exception ex)
            {
                BadRequest(ex.Message);
            }
        }

    }
}
