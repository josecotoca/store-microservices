using AutoMapper;
using MediatR;
using Store.Api.ShopinCart.Api.Dtos;
using Store.Api.ShopinCart.Persistence.Entities;
using Store.Api.ShopinCart.Persistence.Repositories;
using Store.Api.ShopinCart.Remote;
using Store.Api.ShopinCart.Remote.Interface;

namespace Store.Api.ShopinCart.Services.Queries
{
    public class QueryGetSale
    {
        public class SaleGetResponse : IRequest<SaleDto>
        {
            public int Id { get; set; }
        }

        public class Manager : IRequestHandler<SaleGetResponse, SaleDto>
        {
            private readonly ISaleRepository saleRepository;
            private readonly ISaleDetailRepository saleDetailRepository;
            private readonly IProductService productService;
            private readonly IMapper mapper;

            public Manager(ISaleRepository _saleRepository, ISaleDetailRepository _saleDetailRepository, IMapper _mapper, IProductService _productService)
            {
                saleRepository = _saleRepository;
                saleDetailRepository = _saleDetailRepository;
                mapper = _mapper;
                productService = _productService;
            }
            
            public async Task<SaleDto> Handle(SaleGetResponse request, CancellationToken cancellationToken)
            {
                var list = await saleRepository.GetByIdAsync(request.Id);
                var result = mapper.Map<Sale, SaleDto>(list);
                var detail = await saleDetailRepository.GetBySaleIdAsync(request.Id);

                foreach (var item in detail) {
                  var response =  await productService.GetProduct(item.ProductId);

                  if(response.resul) {
                    var productDetail = response.product;
                        var cartDetail = new SaleDetailDto
                        {
                            Description = productDetail.Description,
                            Price = productDetail.Price,
                            ProductId = item.ProductId,
                            Quantity = item.Quantity,
                            SubTotal = item.SubTotal,
                        };

                        result.Detail.Add(cartDetail);

                  }
                }
                return result;
            }
        }
    }
}
