using AutoMapper;
using MediatR;
using Store.Api.Products.Api.Dtos;
using Store.Api.Products.Persistence.Entities;
using Store.Api.Products.Persistence.Repositories;

namespace Store.Api.Products.Services.Queries
{
    public class QueryGetProducts
    {
        public class ProductGetResponse : IRequest<List<ProductDto>>
        {

        }
        public class Manager : IRequestHandler<ProductGetResponse, List<ProductDto>>
        {
            private readonly IQueryProductRepository productRepository;
            private readonly IMapper mapper;

            public Manager(IQueryProductRepository _productRepository, IMapper _mapper)
            {
                productRepository = _productRepository;
                mapper = _mapper;
            }

            public async Task<List<ProductDto>> Handle(ProductGetResponse request, CancellationToken cancellationToken)
            {
                var list = await productRepository.GetAllAsync();
                var result = mapper.Map<List<Product>,List<ProductDto>>(list);
                return result;
            }
        }
    }
}
