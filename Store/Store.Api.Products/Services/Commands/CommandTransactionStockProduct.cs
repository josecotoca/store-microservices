using AutoMapper;
using MediatR;
using Store.Api.Products.Persistence.Entities;
using Store.Api.Products.Persistence.Repositories;

namespace Store.Api.Products.Services.Commands
{
    public class CommandTransactionStockProduct
    {
        public class Manager : IRequestHandler<RequestProductTransaction>
        {
            private readonly ICommandProductRepository commandProductRepository;
            private readonly IQueryProductRepository queryProductRepository;

            public Manager(ICommandProductRepository _commandproductRepository, IQueryProductRepository _queryproductRepository, IMapper _mapper)
            {
                commandProductRepository = _commandproductRepository;
                queryProductRepository = _queryproductRepository;
            }
            private bool IsNotAvailableStock(Product product,double quantity)
            {
                return product.Stock < quantity;
            }

            private void applyDelivered(Product product, bool revenue, double quantity)
            {
                if (revenue)
                    product.Stock += quantity;
                else {

                    if (IsNotAvailableStock(product, quantity))
                        throw new Exception($"Product {product.Id} not available stock.");
                    
                    product.Stock -= quantity;
                    //Output for second step
                    product.StockPendingDelivery += quantity;
                }
                product.UpdatedDate = DateTime.UtcNow;
            }

            private async Task applyTransactionAsync(RequestProductTransaction request)
            {
                foreach (var item in request.detail)
                {
                    var product = await queryProductRepository.GetByIdAsync(item.ProductId);

                    if (product == null)
                        throw new Exception($"Product {item.ProductId} not found.");

                    if (product.ForInventory)
                    {
                        this.applyDelivered(product, request.IsRevenue, item.Quantity);

                        await commandProductRepository.UpdateAsync(product);
                    }
                    else
                        continue;
                }
            }

            public async Task<Unit> Handle(RequestProductTransaction request, CancellationToken cancellationToken)
            {
                await applyTransactionAsync(request);
                return Unit.Value;
            }
        }
    }
}
