using Baby_Shop.Model;

namespace Baby_Shop.Interface
{
    public interface IProductRepository
    {
        public Task<List<Product>> getAllProductAsync();
        public Task<Product> getProductsAsync(int id);
        public Task<int> CreateProductAsync(Product product);
        public Task UpdateProductAsync(int id, Product product);
        public Task DeleteProductAsync(int id);
    }
}
