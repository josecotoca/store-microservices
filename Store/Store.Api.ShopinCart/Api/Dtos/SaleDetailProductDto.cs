namespace Store.Api.ShopinCart.Api.Dtos
{
    public class SaleDetailProductDto: SaleDetailDto
    {
        public int Id { get; set; }
        public double Charge { get; set; }
        public double Total { get; set; }
    }
}
