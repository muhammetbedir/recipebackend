using Recipe.Domain.Models;
using System.Linq.Expressions;

namespace Recipe.Application.Repository
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        T GetById(Guid id);
        Task<T> GetByIdAsync(Guid id);
        Task<T> InsertAsync(T obj);
        T Insert(T obj);
        Task UpdateAsync(T obj);
        Task UpdateAsync(T entity, params Expression<Func<T, object>>[] updatedProperties);
        void Update(T obj);
        IQueryable<T> GetAll(Expression<Func<T, bool>> expression = null);
        Task<List<T>> GetAllAsync(Expression<Func<T, bool>> expression = null);
        Task<T> GetSingleAsync(Expression<Func<T, bool>> expression);
        T GetSingle(Expression<Func<T, bool>> expression);
        Task deleteAsync(T obj);
        Task deleteByIdAsync(Guid id);
        void delete(T obj);
        void deleteById(Guid id);
        void Commit();
        Task CommitAsync();
    }
}
