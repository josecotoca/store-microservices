using AutoMapper;
using MediatR;
using Store.Api.Products.Api.Dtos;
using Store.Api.Products.Persistence.Repositories;

namespace Store.Api.Products.Services.Commands
{
    public class CommandEditProduct
    {
        public class ProductEditRequest : RequestProduct
        {
        }
        public class Manager : IRequestHandler<ProductEditRequest>
        {
            private readonly ICommandProductRepository commandProductRepository;
            private readonly IQueryProductRepository queryProductRepository;

            public Manager(ICommandProductRepository _commandproductRepository, IQueryProductRepository _queryproductRepository, IMapper _mapper)
            {
                commandProductRepository = _commandproductRepository;
                queryProductRepository = _queryproductRepository;
            }

            public async Task<Unit> Handle(ProductEditRequest request, CancellationToken cancellationToken)
            {
                var product = await queryProductRepository.GetByIdAsync(request.Id);
                if (product == null)
                {
                    throw new Exception("Product not found.");
                }

                product.Name = request.Name;
                product.Description = request.Description;
                product.UpdatedDate = DateTime.UtcNow;
                product.ForInventory = request.ForInventory;
                product.ForSale = request.ForSale;
                product.Price = request.Price;

                await commandProductRepository.UpdateAsync(product);
                return Unit.Value;
            }
        }
    }
}