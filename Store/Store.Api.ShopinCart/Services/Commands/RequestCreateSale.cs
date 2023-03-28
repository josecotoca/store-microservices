using MediatR;
using Store.Api.ShopinCart.Api.Dtos;
using static Store.Api.ShopinCart.Services.Commands.CommandCreateSale;

namespace Store.Api.ShopinCart.Services.Commands
{
    public class RequestCreateSale : IRequest
    {
        public string InvoiceName { get; set; }
        public string InvoiceNit { get; set; }
        public string? Observation { get; set; }
        public DateTime Date { get; set; } = DateTime.UtcNow;
        public string Delivered { get; set; } = "PENDING";
        public double SubTotal { get; set; } = 0d;
        public double ChargeTax { get; set; } = 0d;
        public double Total { get; set; } = 0d;

        public List<RequestCreateSaleDetail> Detail { get; set; }
    }
}
