using System.ComponentModel.DataAnnotations.Schema;

namespace Store.Api.ShopinCart.Persistence.Entities
{
    [Table("sales_details")]
    public class SaleDetail : BaseEntity
    {
        [Column("sale_id")]
        public int SaleId { get; set; }
        public Sale sale { get; set; }

        [Column("product_id")]
        public int ProductId { get; set; }

        [Column("description")]
        public string Description { get; set; }

        [Column("quantity")]
        public double Quantity { get; set; }

        [Column("price")]
        public double Price { get; set; }

        [Column("subtotal")]
        public Double SubTotal { get; set; } = 0d;

        [Column("charge_tax")]
        public Double ChargeTax { get; set; } = 0d;

        [Column("total")]
        public Double Total { get; set; } = 0d;
    }
}
