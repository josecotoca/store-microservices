using AutoMapper;
using MediatR;
using Store.Api.Products.Persistence.Entities;
using Store.Api.Products.Persistence.Repositories;

namespace Store.Api.Products.Services.Commands
{
    public class CommandDeliveredStockProduct
    {
        public class Manager : IRequestHandler<RequestDeliveredProduct>
        {
            private readonly ICommandProductRepository commandProductRepository;
            private readonly IQueryProductRepository queryProductRepository;

            public Manager(ICommandProductRepository _commandproductRepository, IQueryProductRepository _queryproductRepository, IMapper _mapper)
            {
                commandProductRepository = _commandproductRepository;
                queryProductRepository = _queryproductRepository;
            }
            private bool IsNotAvailableDeliverStock(Product product, double quantity)
            {
                return product.StockPendingDelivery < quantity;
            }

            private void applyDelivered(Product product, double quantity)
            {
                    if (IsNotAvailableDeliverStock(product, quantity))
                        throw new Exception($"Product {product.Id} not available stock.");
                    //Second step
                    product.StockPendingDelivery -= quantity;
                    product.UpdatedDate = DateTime.UtcNow;
            }

            private async Task applyTransactionAsync(RequestDeliveredProduct request)
            {
                foreach (var item in request.detail)
                {
                    var product = await queryProductRepository.GetByIdAsync(item.ProductId);

                    if (product == null)
                        throw new Exception($"Product {item.ProductId} not found.");

                    if (product.ForInventory)
                    {
                        this.applyDelivered(product, item.Quantity);

                        await commandProductRepository.UpdateAsync(product);
                    }
                    else
                        continue;
                }
            }

            public async Task<Unit> Handle(RequestDeliveredProduct request, CancellationToken cancellationToken)
            {
                await applyTransactionAsync(request);
                return Unit.Value;
            }
        }
    }
}
