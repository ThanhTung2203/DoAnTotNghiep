using Baby_Shop.Model;
using Baby_Shop.Models;

namespace Baby_Shop.Interface
{
    public interface IImageProduct
    {
        Task<ImageProduct> UploadImageAsync(IFormFile image);

        Task DeleteImageAsync(int id);
    }
}
