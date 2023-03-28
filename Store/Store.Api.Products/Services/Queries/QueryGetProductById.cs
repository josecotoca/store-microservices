using AutoMapper;
using MediatR;
using Store.Api.Products.Api.Dtos;
using Store.Api.Products.Persistence.Entities;
using Store.Api.Products.Persistence.Repositories;

namespace Store.Api.Products.Services.Queries
{
    public class QueryGetProductById
    {
        public class ProductById : IRequest<ProductDto>
        {
            public int Id { get; set; }
        }

        public class Manager : IRequestHandler<ProductById, ProductDto>
        {
            private readonly IQueryProductRepository productRepository;
            private readonly IMapper mapper;

            public Manager(IQueryProductRepository _productRepository, IMapper _mapper)
            {
                productRepository = _productRepository;
                mapper = _mapper;
            }

            public async Task<ProductDto> Handle(ProductById request, CancellationToken cancellationToken)
            {
                var product = await productRepository.GetByIdAsync(request.Id);
                if (product == null)
                    throw new Exception("Product not found");

                var result = mapper.Map<Product, ProductDto>(product);

                return result;
            }
        }
    }
}
