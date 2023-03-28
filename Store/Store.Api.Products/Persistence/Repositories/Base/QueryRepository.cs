using Microsoft.EntityFrameworkCore;
using Store.Api.Products.Persistence.Entities;
using System.Linq.Expressions;

namespace Store.Api.Products.Persistence.Repositories.Base
{
    public class QueryRepository<T> : IQueryRepository<T> where T : BaseEntity
    {
        protected readonly ContextProduct dbContext;

        public QueryRepository(ContextProduct _dbContext)
        {
            dbContext = _dbContext;
        }
        public async Task<List<T>> GetAllAsync()
        {
            return await dbContext.Set<T>().ToListAsync();
        }

        public async Task<List<T>> GetAsync(Expression<Func<T, bool>> predicate)
        {
            return await dbContext.Set<T>().Where(predicate).ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await dbContext.Set<T>().FindAsync(id);
        }
    }
}
