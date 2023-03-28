using Store.Api.Products.Persistence.Entities;
using Store.Api.Products.Persistence.Repositories.Base;

namespace Store.Api.Products.Persistence.Repositories
{
    public class QueryProductRepository : QueryRepository<Product>, IQueryProductRepository
    {
        public QueryProductRepository(ContextProduct dbContext) : base(dbContext)
        {

        }
    }
}