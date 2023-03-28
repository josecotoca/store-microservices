using System.ComponentModel.DataAnnotations.Schema;

namespace Store.Api.ShopinCart.Persistence.Entities
{
    [Table("sales")]
    public class Sale : BaseEntity
    {
        [Column("invoice_name")]
        public string InvoiceName { get; set; }

        [Column("invoice_nit")]
        public string InvoiceNit { get; set; }

        [Column("observation")]
        public string? Observation { get; set; }

        [Column("date")]
        public DateTime Date { get; set; } = DateTime.UtcNow;

        [Column("delivered")]
        public string Delivered { get; set; } = "PENDING";

        [Column("date_delivered")]
        public DateTime? DateDelivered { get; set; }

        [Column("subtotal")]
        public double SubTotal { get; set; } = 0d;

        [Column("charge_tax")]
        public double ChargeTax { get; set; } = 0d;

        [Column("total")]
        public double Total { get; set; } = 0d;
    }
}
