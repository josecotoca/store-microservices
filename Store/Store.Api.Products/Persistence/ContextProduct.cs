using Microsoft.EntityFrameworkCore;
using Store.Api.Products.Persistence.Entities;

namespace Store.Api.Products.Persistence
{
    public class ContextProduct : DbContext
    {
        public ContextProduct(DbContextOptions<ContextProduct> options) : base(options) { }
        public DbSet<Product> Product { get; set; }

    }
}
