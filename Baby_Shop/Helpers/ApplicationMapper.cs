using AutoMapper;
using Baby_Shop.Data;
using Baby_Shop.Model;

namespace Baby_Shop.Helpers
{
    public class ApplicationMapper:Profile
    {
        public ApplicationMapper()
        {
            CreateMap<ProductData, Product>().ReverseMap();
        }
    }
}
