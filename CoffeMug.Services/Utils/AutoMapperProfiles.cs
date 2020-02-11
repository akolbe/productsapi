using AutoMapper;
using CoffeMug.Services.Models;
using CoffeMug.Services.Services.Dtos;

namespace CoffeMug.Services.Utils
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Product,ProductDto>();
            CreateMap<ProductDto,Product>();
        }
    }
}