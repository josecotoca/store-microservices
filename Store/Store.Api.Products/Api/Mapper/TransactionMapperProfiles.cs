using AutoMapper;
using static Store.Api.Products.Services.Commands.CommandEditProduct;
using Store.Api.Products.Api.Dtos;
using Store.Api.Products.Persistence.Entities;
using Store.Api.Products.Services.Commands;

namespace Store.Api.Products.Api.Mapper
{
    public class TransactionMapperProfiles : Profile
    {
        public TransactionMapperProfiles()
        {
            CreateMap<RequestProductTransaction, TransactionDto>().ReverseMap();
            CreateMap<RequestProductTransactionDetail, TransactionDetailDto>().ReverseMap();
            CreateMap<RequestDeliveredProduct, DeliverTransactionDto>().ReverseMap();
        }
    }
}
