using Store.Api.Products.Persistence.Entities;
using Store.Api.Products.Persistence.Repositories.Base;

namespace Store.Api.Products.Persistence.Repositories
{
    public class CommandProductRepository : CommandRepository<Product>, ICommandProductRepository
    {
        public CommandProductRepository(ContextProduct dbContext) : base(dbContext)
        {

        }
    }
}
