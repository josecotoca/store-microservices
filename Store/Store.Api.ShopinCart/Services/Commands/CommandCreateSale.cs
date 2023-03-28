using AutoMapper;
using MediatR;
using Microsoft.Extensions.Configuration;
using Store.Api.ShopinCart.Api.Dtos;
using Store.Api.ShopinCart.Persistence.Entities;
using Store.Api.ShopinCart.Persistence.Repositories;
using Store.Api.ShopinCart.Remote;
using Store.Api.ShopinCart.Remote.Interface;
using System.ComponentModel.DataAnnotations.Schema;

namespace Store.Api.ShopinCart.Services.Commands
{
    public class CommandCreateSale
    {

        public class Manager : IRequestHandler<RequestCreateSale>
        {
            private readonly ISaleRepository saleRepository;
            private readonly ISaleDetailRepository saleDetailRepository;
            private readonly IMapper mapper;
            private readonly IConfiguration Configuration;
            private readonly IProductService productService;
            private double TaxIva = 0d;
            public Manager(ISaleRepository _saleRepository, ISaleDetailRepository _saleDetailRepository, IConfiguration _configuration, IProductService _productService)
            {
                Configuration = _configuration;
                saleRepository = _saleRepository;
                saleDetailRepository = _saleDetailRepository;
                TaxIva = double.Parse(Configuration["ConfigApp:TAX_IVA"]);
                productService = _productService;
            }

            public async Task<Unit> Handle(RequestCreateSale request, CancellationToken cancellationToken)
            {
                RemoteTransaction dataRemote = new RemoteTransaction { IsRevenue= false };

                var charge = ToolNumber.calculatePercent(request.SubTotal, TaxIva);
                
                var sale = new Sale
                {
                    InvoiceName = request.InvoiceName,
                    InvoiceNit = request.InvoiceNit,
                    Observation = request.Observation,
                    Date = request.Date,
                    SubTotal = request.SubTotal,
                    ChargeTax = charge,
                    Total = request.SubTotal + charge
                };

                if (request.SubTotal == 0)
                    throw new Exception("Error Creating Sale.");

                var value = await saleRepository.AddAsync(sale);
                if (value == 0)
                    throw new Exception("Error Creating Sale.");

                var chargeTotal = 0d;
                var SaleId = sale.Id;

                foreach (var item in request.Detail)
                {
                    var chargeDetail  = ToolNumber.calculatePercent(item.SubTotal, TaxIva);

                    var SubToTal = 0d;
                    SubToTal = Math.Round((item.Quantity * item.Price), 2);

                    if (SubToTal != Math.Round(item.SubTotal,2))
                        throw new Exception("Error Product calculation.");

                    var detalle = new SaleDetail
                    {
                        SaleId = SaleId,
                        ProductId = item.ProductId,
                        Description = item.Description,
                        Price = item.Price,
                        Quantity = item.Quantity,
                        SubTotal = item.SubTotal,
                        ChargeTax = chargeDetail,
                        Total = item.SubTotal + chargeDetail
                    };

                    var result = await saleDetailRepository.AddAsync(detalle);

                    if (result == 0)
                        throw new Exception("Error detail no charge data.");

                    var detailRemote = new RemoteTransactionDetail { ProductId = item.ProductId, Quantity = item.Quantity };
                    dataRemote.detail.Add(detailRemote);
                }
                var responseRemote = await productService.SetTransactionPost(dataRemote, "Products", "api/transactions");
                if (!responseRemote.resul)
                    throw new Exception("Error of transaction.");

                return Unit.Value; 
            }
        }
    }
}
