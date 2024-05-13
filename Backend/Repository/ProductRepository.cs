using AutoMapper;
using Backend.Data;
using Backend.Dto;
using Backend.Interfaces;
using Backend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Backend.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly APIContext _context;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _env;

        public ProductRepository(APIContext context, IMapper mapper, IWebHostEnvironment env)
        {
            _context = context;
            _mapper = mapper;
            _env = env;
        }
        public async Task<int> AddProductAsync([FromForm]Product product)
        {
            //var newProdct=_mapper.Map<Product>(product);
            //_context.Products.Add(newProdct);
            //await _context.SaveChangesAsync();
            //return newProdct.Id;

            //

            product.Image = "";
            //var newProdct = _mapper.Map<Product>(product);
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
            if (product.ImageFile != null)
            {
                var fileName = product.Id.ToString() + Path.GetExtension(product.ImageFile.FileName);
                var uploadFolder = Path.Combine(_env.WebRootPath, "images", "products");
                var uploadPath = Path.Combine(uploadFolder, fileName);
                using (FileStream fs = System.IO.File.Create(uploadPath))
                {
                    product.ImageFile.CopyTo(fs);
                    fs.Flush();
                }
                product.Image = fileName;
                _context.Products.Update(product);
                _context.SaveChanges();
            }
            return product.Id;
        }

        public async Task DeleteProductAsync(int id)
        {
            var deleteProduct = await _context.Products.FindAsync(id);
            if (deleteProduct != null)
            {
                _context.Products!.Remove(deleteProduct);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<Product>> getAllProductAsync()
        {
            return await _context.Products.ToListAsync();
        }

        public async Task<Product> getProductByIdAsync(int id)
        {
            return await _context.Products.FindAsync(id);

        }

        public async Task updateProductAsync(int id, Product product)
        {
            if (id == product.Id)
            {
                //var updateProduct = _mapper.Map<Product>(product);
                //_context.Products.Update(updateProduct);
                //await _context.SaveChangesAsync();
                _context.Products.Update(product);
                await _context.SaveChangesAsync();
            }
        }
    }
}
