namespace Store.Api.ShopinCart.Services.Commands
{
    public class RequestCreateSaleDetail
    {
        public int SaleId { get; set; }
        public int ProductId { get; set; }
        public string? Description { get; set; }
        public double Quantity { get; set; }
        public double Price { get; set; }
        public double SubTotal { get; set; }
        public double ChargeTax { get; set; }
        public double Total { get; set; }
    }
}
