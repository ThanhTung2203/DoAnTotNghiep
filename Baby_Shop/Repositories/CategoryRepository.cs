using AutoMapper;
using Baby_Shop.Data;
using Baby_Shop.Interface;
using Baby_Shop.Model;
using Microsoft.EntityFrameworkCore;

namespace Baby_Shop.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly DatabaseContext _context;
         

        public CategoryRepository(DatabaseContext context )
        {
            _context = context;
           
        }
        public async Task<int> createCategoriesAsync(Category category)
        {
            _context.Categories.Add(category);
            await _context.SaveChangesAsync();
            return category.Id;
        }

        public async Task deleteCategoriesAsync(int id)
        {
            var deleteCategory = await _context.Categories!.FindAsync(id);
            if (deleteCategory != null)
            {
                _context.Categories!.Remove(deleteCategory);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<Category>> getAllCategoriesAsync()
        {
            return await _context.Categories.ToListAsync();
        }

        public async Task updateCategoriesAsync( Category category)
        {
            _context.Categories.Update(category);
            await _context.SaveChangesAsync();
        }
    }
}
