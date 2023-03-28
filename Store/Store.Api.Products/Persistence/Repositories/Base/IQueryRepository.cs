using MediatR;
using Store.Api.Products.Persistence.Entities;
using System.Linq.Expressions;

namespace Store.Api.Products.Persistence.Repositories.Base
{
    public interface IQueryRepository<T> where T : BaseEntity
    {
        Task<List<T>> GetAllAsync();
        Task<List<T>> GetAsync(Expression<Func<T, bool>> predicate);
        Task<T> GetByIdAsync(int id);
    }
}
