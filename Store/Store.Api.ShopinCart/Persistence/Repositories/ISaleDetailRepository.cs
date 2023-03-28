using Microsoft.EntityFrameworkCore;
using Store.Api.ShopinCart.Persistence.Entities;
using Store.Api.ShopinCart.Persistence.Repositories.Base;

namespace Store.Api.ShopinCart.Persistence.Repositories
{
    public interface ISaleDetailRepository : IRepository<SaleDetail>
    {
        Task<List<SaleDetail>> GetBySaleIdAsync(int id);

    }
}
