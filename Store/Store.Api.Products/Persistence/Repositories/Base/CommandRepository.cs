using MediatR;
using Microsoft.EntityFrameworkCore;
using Store.Api.Products.Persistence.Entities;
using System.Linq.Expressions;

namespace Store.Api.Products.Persistence.Repositories.Base
{
    public class CommandRepository<T> : ICommandRepository<T> where T : BaseEntity
    {
        protected readonly ContextProduct dbContext;

        public CommandRepository(ContextProduct dbContext)
        {
            this.dbContext = dbContext;
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

        public async Task DeleteAsync(T entity)
        {
            dbContext.Set<T>().Remove(entity);
            await dbContext.SaveChangesAsync();
        }        
    }
}
