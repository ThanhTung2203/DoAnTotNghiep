using Backend.Models;

namespace Backend.Interfaces
{
    public interface IProductRepository
    {
        
        public Task<List<Product>> getAllProductAsync();
        public Task<Product> getProductByIdAsync(int id);
        public Task<int>AddProductAsync(Product product);
        public Task updateProductAsync(int id, Product product);
        public Task DeleteProductAsync(int id);

    }
}
