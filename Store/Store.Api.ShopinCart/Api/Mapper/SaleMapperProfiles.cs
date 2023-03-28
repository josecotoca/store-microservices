using AutoMapper;
using Store.Api.ShopinCart.Api.Dtos;
using Store.Api.ShopinCart.Persistence.Entities;
using Store.Api.ShopinCart.Services.Commands;

namespace Store.Api.ShopinCart.Api.Mapper
{
    public class SaleMapperProfiles : Profile
    {
        public SaleMapperProfiles() {
            CreateMap<SaleDto, RequestCreateSale>().ReverseMap();
            CreateMap<Sale, SaleDto>().ReverseMap();
            CreateMap<SaleDetailDto, SaleDetail>().ReverseMap();
            CreateMap<SaleDetailDto, RequestCreateSaleDetail>().ReverseMap();
        }
    }
}
