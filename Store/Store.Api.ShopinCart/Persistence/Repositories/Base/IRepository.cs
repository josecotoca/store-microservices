using Store.Api.ShopinCart.Persistence.Entities;
using System.Linq.Expressions;

namespace Store.Api.ShopinCart.Persistence.Repositories.Base
{
    public interface IRepository<T> where T : BaseEntity
    {
        Task<int> AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task<List<T>> GetAllAsync();
        Task<List<T>> GetAsync(Expression<Func<T, bool>> predicate);
        Task<T> GetByIdAsync(int id);
    }
}
