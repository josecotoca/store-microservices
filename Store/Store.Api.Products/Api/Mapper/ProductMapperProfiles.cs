using AutoMapper;
using Store.Api.Products.Api.Dtos;
using Store.Api.Products.Persistence.Entities;
using Store.Api.Products.Services.Commands;
using static Store.Api.Products.Services.Commands.CommandEditProduct;

namespace Store.Api.Products.Api.Mapper
{
    public class ProductMapperProfiles : Profile
    {
        public ProductMapperProfiles() {
            CreateMap<ProductAddDto, RequestProduct>();
            CreateMap<RequestProduct, Product>();
            CreateMap<ProductAddDto, Product>();
            CreateMap<ProductDto, Product>().ReverseMap();
            CreateMap<RequestProduct, Product>().ReverseMap();
            CreateMap<ProductEditRequest, ProductEditDto>().ReverseMap();
        }
    }
}
