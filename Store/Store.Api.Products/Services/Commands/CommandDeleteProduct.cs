using AutoMapper;
using MediatR;
using Store.Api.Products.Api.Dtos;
using Store.Api.Products.Persistence.Entities;
using Store.Api.Products.Persistence.Repositories;

namespace Store.Api.Products.Services.Commands
{
    public class CommandDeleteProduct
    {
        public class DeleteById : IRequest
        {
            public int Id { get; set; }
        }

        public class Manager : IRequestHandler<DeleteById>
        {
            private readonly ICommandProductRepository commandProductRepository;
            private readonly IQueryProductRepository queryProductRepository;
            private readonly IMapper mapper;

            public Manager(ICommandProductRepository _productRepository, IQueryProductRepository _queryProductRepository, IMapper _mapper)
            {
                commandProductRepository = _productRepository;
                queryProductRepository = _queryProductRepository;
                mapper = _mapper;
            }

            public async Task<Unit> Handle(DeleteById request, CancellationToken cancellationToken)
            {
                var product = await queryProductRepository.GetByIdAsync(request.Id);
                if (product == null)
                    throw new Exception("Error Product not found");

                if(product.Stock > 0 || product.StockPendingDelivery > 0)
                    throw new Exception("Error Product with stock");

                await commandProductRepository.DeleteAsync(product);

                return Unit.Value;
            }
        }
    }
}
