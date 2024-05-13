using AutoMapper;
using Baby_Shop.Data;
using Baby_Shop.Interface;
using Baby_Shop.Model;
using Microsoft.EntityFrameworkCore;

namespace Baby_Shop.Repositories
{
    public class ProductPepository : IProductRepository
    {
        private readonly DatabaseContext _context;
        private readonly IMapper _mapper;

        public ProductPepository(DatabaseContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

       

        public async Task<int> CreateProductAsync(Product product )
        {
            var createProduct=_mapper.Map<ProductData>(product);
            _context.Products!.Add(createProduct);
            await _context.SaveChangesAsync();
            return createProduct.Id;
        }

      

        public async Task DeleteProductAsync(int id)
        {
             var deleteProduct= await _context.Products!.FindAsync(id);
            if(deleteProduct != null)
            {
                _context.Products!.Remove(deleteProduct);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<Product>> getAllProductAsync()
        {
            var products = await _context.Products!.ToListAsync();
            return _mapper.Map<List<Product>>(products);
        }

        public async Task<Product> getProductsAsync(int id)
        {
            var products = await _context.Products!.FindAsync(id);
            return _mapper.Map<Product>(products);
        }

     

        public async Task UpdateProductAsync(int id, Product product)
        {
            if (id == product.Id)
            {
                var updateProduct=_mapper.Map<ProductData>(product);
                _context.Products!.Update(updateProduct);
                await _context.SaveChangesAsync();
            }
        }
    }
}
