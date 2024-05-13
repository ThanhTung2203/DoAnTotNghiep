using Baby_Shop.Model;

namespace Baby_Shop.Interface
{
    public interface ICategoryRepository
    {
        public Task<List<Category>> getAllCategoriesAsync();
        public Task<int> createCategoriesAsync(Category category);
        public Task updateCategoriesAsync(Category category);
        public Task deleteCategoriesAsync(int id);
    }
}
