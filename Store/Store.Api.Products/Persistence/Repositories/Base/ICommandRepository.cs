using Store.Api.Products.Persistence.Entities;

namespace Store.Api.Products.Persistence.Repositories.Base
{
    public interface ICommandRepository<T> where T : BaseEntity
    {
        Task<int> AddAsync(T entity);

        Task UpdateAsync(T entity);

        Task DeleteAsync(T entity);
    }
}
