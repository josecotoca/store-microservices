using Microsoft.EntityFrameworkCore;
using Store.Api.ShopinCart.Persistence.Entities;
using Store.Api.ShopinCart.Persistence.Repositories.Base;

namespace Store.Api.ShopinCart.Persistence.Repositories
{
    public class SaleDetailRepository : Repository<SaleDetail>, ISaleDetailRepository
    {
        protected readonly ContextCart dbContext;
        
        public SaleDetailRepository(ContextCart _dbContext) : base(_dbContext)
        {
            dbContext = _dbContext;
        }

        public async Task<List<SaleDetail>> GetBySaleIdAsync(int id)
        {
            return await dbContext.SaleDetail.Where(x => x.SaleId == id).ToListAsync();
        }
    }
}
