using System.ComponentModel;

namespace Store.Api.ShopinCart.Api.Dtos
{
    public class SaleDetailDto
    {
        [DefaultValue(1)]
        public int ProductId { get; set; }
        [DefaultValue("POLERA BLANCA HERING")]
        public string? Description { get; set; }
        [DefaultValue(1)]
        public double Quantity { get; set; }
        [DefaultValue(100)]
        public double Price { get; set; }
        [DefaultValue(100)]
        public double SubTotal { get; set; }
    }
}
