using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Numerics;

namespace Store.Api.Products.Persistence.Entities
{
    [Table("products")]
    public class Product : BaseEntity
    {
        [Column("code")]
        public string Code { get; set; }

        [Column("name")]
        public string Name { get; set; }

        [Column("description")]
        public string? Description { get; set; }

        [Column("for_inventory")]
        public bool ForInventory { get; set; }

        [Column("for_sale")]
        public bool ForSale { get; set; }

        [Column("price")]
        public double Price { get; set; }

        [Column("stock")]
        public double Stock { get; set; } = 0d;

        [Column("stock_pending_delivery")]
        public double StockPendingDelivery { get; set; } = 0d;

        [Column("created_at")]
        public DateTime CreationDate { get; set; } = DateTime.UtcNow;

        [Column("updated_at")]
        public DateTime? UpdatedDate { get; set; }

        [Column("state")]
        public bool State { get; set; } = true;
    }
}
