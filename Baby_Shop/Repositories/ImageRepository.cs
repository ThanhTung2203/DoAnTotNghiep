using Baby_Shop.Interface;
using Baby_Shop.Models;
using Microsoft.AspNetCore.Hosting;

namespace Baby_Shop.Repositories
{
    //public class ImageRepository : IImageProduct
    //{
    //    private readonly string _uploadImage;
    //    public ImageRepository(IConfiguration configuration)
    //    {
    //        _uploadImage = configuration.GetValue<string>("UploadImage");
    //    }
    //    public Task DeleteImageAsync(int id)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public async Task<ImageProduct> UploadImageAsync(IFormFile image)
    //    {
    //        if (image == null || image.Length == 0)
    //        {
    //            throw new ArgumentException("File not selected or empty");
    //        }

    //        var fileName = Guid.NewGuid().ToString() + Path.GetExtension(image.FileName);
    //        var filePath = Path.Combine(_uploadImage, fileName);

    //        using (var stream = new FileStream(filePath, FileMode.Create))
    //        {
    //            await image.CopyToAsync(stream);
    //        }
    //        var imageProduct = new ImageProduct
    //        {
    //            Name=fileName
    //        };
    //        return imageProduct;
    //    }
    //}
    
}
