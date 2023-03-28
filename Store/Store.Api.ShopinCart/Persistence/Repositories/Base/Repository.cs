using Microsoft.EntityFrameworkCore;
using Store.Api.ShopinCart.Persistence.Entities;
using System.Linq.Expressions;

namespace Store.Api.ShopinCart.Persistence.Repositories.Base
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        protected readonly ContextCart dbContext;

        public Repository(ContextCart _dbContext)
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

        public async Task<int> AddAsync(T entity)
        {
            dbContext.Set<T>().Add(entity);
            var result = await dbContext.SaveChangesAsync();
            return result;
        }

        public async Task UpdateAsync(T entity)
        {
            dbContext.Entry(entity).State = EntityState.Modified;
            await dbContext.SaveChangesAsync();
        }
    }
}
