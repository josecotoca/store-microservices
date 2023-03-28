using AutoMapper;
using MediatR;
using Store.Api.ShopinCart.Persistence.Entities;
using Store.Api.ShopinCart.Persistence.Repositories;
using Store.Api.ShopinCart.Remote.Interface;
using Store.Api.ShopinCart.Remote;
using Store.Api.ShopinCart.Api.Dtos;

namespace Store.Api.ShopinCart.Services.Commands
{
    public class CommandDeliverSale
    {
        public class RequestDeliverSale : IRequest
        {
            public int Id { get; set; }
        }

        public class Manager : IRequestHandler<RequestDeliverSale>
        {
            private readonly ISaleRepository saleRepository;
            private readonly ISaleDetailRepository saleDetailRepository;
            private readonly IMapper mapper;
            private readonly IProductService productService;
            public Manager(ISaleRepository _saleRepository, ISaleDetailRepository _saleDetailRepository, IProductService _productService)
            {
                saleRepository = _saleRepository;
                saleDetailRepository = _saleDetailRepository;
                productService = _productService;
            }

            public async Task<Unit> Handle(RequestDeliverSale request, CancellationToken cancellationToken)
            {

                var sale = await saleRepository.GetByIdAsync(request.Id);

                sale.Delivered = "COMPLETED";
                await saleRepository.UpdateAsync(sale);

                var detail = await saleDetailRepository.GetBySaleIdAsync(request.Id);

                var deliverTransaction = new DeliverTransaction();

                foreach (var item in detail)
                {
                    var detailRemote = new RemoteTransactionDetail { ProductId = item.ProductId, Quantity = item.Quantity };
                    deliverTransaction.detail.Add(detailRemote);
                }
                var responseRemote = await productService.SetTransactionPost(deliverTransaction, "Products", "api/transactions/deliver");
                if (!responseRemote.resul)
                    throw new Exception("Error of transaction.");

                return Unit.Value;
            }
        }
    }
}
