using Microsoft.EntityFrameworkCore;
using Store.Api.ShopinCart.Persistence.Entities;

namespace Store.Api.ShopinCart.Persistence
{
    public class ContextCart : DbContext
    {
        public ContextCart(DbContextOptions<ContextCart> options) : base(options) { }
        public DbSet<Sale> Sale { get; set; }
        public DbSet<SaleDetail> SaleDetail { get; set; }
    }
}
