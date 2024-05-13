using Baby_Shop.Helpers;
using Baby_Shop.Interface;
using Baby_Shop.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Baby_Shop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryRepository _Repo;

        public CategoriesController(ICategoryRepository Repo)
        {
            _Repo = Repo;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllCategoriesAsync()
        {
            var categories = await _Repo.getAllCategoriesAsync();
            return Ok(categories);
        }
        [HttpPost]
        [Authorize(Roles =ApplicationRole.Customer)]
        public async Task<IActionResult>createCategoriesAsync(Category category)
        {
            var categories = await _Repo.createCategoriesAsync(category);
            return Ok(categories);
        }
        [HttpPut]
        public async Task<IActionResult>updateCategoriesAsync(int id,Category category)
        {
            if (id != category.Id)
            {
                return BadRequest();
            }

            await _Repo.updateCategoriesAsync(category);
            return NoContent();
        }
        [HttpDelete]
        public async Task<IActionResult>deleteCategoriresSync(int id)
        {
            try
            {
                await _Repo.deleteCategoriesAsync(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error :{ex}");
            }
        }
    }
}
