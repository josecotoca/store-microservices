using System.ComponentModel;

namespace Store.Api.ShopinCart.Remote
{
    public class Product
    {
        public int Id { get; set; }
        public double Stock { get; set; }
        public double StockPendingDelivery { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool ForInventory { get; set; }
        public bool ForSale { get; set; }
        public Double Price { get; set; }
    }
}
