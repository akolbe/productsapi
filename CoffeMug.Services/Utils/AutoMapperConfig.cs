using AutoMapper;
using CoffeMug.Core.Domain;
using CoffeMug.Services.Services.Dtos;

namespace CoffeMug.Services.Utils
{
    public static class AutoMapperConfig
    {
        public static IMapper Initialize()
        {
            return new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Product, ProductDto>();
                cfg.CreateMap<ProductDto, Product>();
				cfg.CreateMap<ProductAddDto, Product>();
            }).CreateMapper();
        }
    }
}