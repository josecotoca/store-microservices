using Store.Api.Products.Persistence.Entities;
using Store.Api.Products.Persistence.Repositories.Base;

namespace Store.Api.Products.Persistence.Repositories
{
    public interface IQueryProductRepository : IQueryRepository<Product>
    {
    }
}
