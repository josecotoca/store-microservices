using Store.Api.ShopinCart.Persistence.Entities;
using Store.Api.ShopinCart.Persistence.Repositories.Base;

namespace Store.Api.ShopinCart.Persistence.Repositories
{
    public class SaleRepository : Repository<Sale>, ISaleRepository
    {
        public SaleRepository(ContextCart _dbContext) : base(_dbContext)
        {
        }
    }
}
