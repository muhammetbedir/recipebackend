using Microsoft.EntityFrameworkCore;
using Recipe.Application.Repository;
using Recipe.Domain.Models;
using Recipe.Infrastructure.Persistence;
using System.Linq.Expressions;

namespace Recipe.Persistence.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        public readonly RecipeAppDbContext _context;
        private readonly DbSet<T> _dbSet;
        public GenericRepository(RecipeAppDbContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        public void Commit()
        {
            _context.SaveChanges();
        }

        public async Task CommitAsync()
        {
            await _context.SaveChangesAsync();
        }


        public void delete(T obj)
        {
            _dbSet.Remove(obj);
        }

        public async Task deleteAsync(T obj)
        {
            await Task.Run(() =>
            {
                _dbSet.Remove(obj);
            });
        }

        public void deleteById(Guid id)
        {
            _dbSet.Remove(_dbSet.FirstOrDefault(x => x.Id == id));
        }

        public async Task deleteByIdAsync(Guid id)
        {
            await Task.Run(() =>
            {
                _dbSet.Remove(_dbSet.FirstOrDefault(x => x.Id == id));
            });

        }

        public IQueryable<T> GetAll(Expression<Func<T, bool>> expression = null)
        {
            return expression == null
                ? _dbSet
                : _dbSet.Where(expression);
        }

        public async Task<List<T>> GetAllAsync(Expression<Func<T, bool>> expression = null)
        {
            return expression == null ? await _dbSet.ToListAsync() : await _dbSet.Where(expression).ToListAsync();
        }

        public T GetById(Guid id)
        {
            return _dbSet.FirstOrDefault(x => x.Id == id);
        }

        public async Task<T> GetByIdAsync(Guid id)
        {
            return await _dbSet.FirstOrDefaultAsync(x => x.Id == id);
        }

        public T GetSingle(Expression<Func<T, bool>> expression)
        {
            return _dbSet.FirstOrDefault(expression);
        }

        public Task<T> GetSingleAsync(Expression<Func<T, bool>> expression)
        {
            return _dbSet.FirstOrDefaultAsync(expression);
        }

        public T Insert(T obj)
        {
            obj.Id = Guid.NewGuid();
            _dbSet.Add(obj);
            return obj;
        }

        public async Task<T> InsertAsync(T obj)
        {
            obj.Id = Guid.NewGuid();
            await _dbSet.AddAsync(obj);
            return obj;
        }

        public void Update(T obj)
        {
            _dbSet.Update(obj);
        }

        public async Task UpdateAsync(T obj)
        {
            await Task.Run(() =>
            {
                _dbSet.Update(obj);
            });
        }

        public async Task UpdateAsync(T entity, params Expression<Func<T, object>>[] updatedProperties)
        {
            //Ensure only modified fields are updated.
            var dbEntityEntry = _dbSet.Entry(entity);
            if (updatedProperties.Any())
            {
                //update explicitly mentioned properties
                foreach (var property in updatedProperties)
                {
                    dbEntityEntry.Property(property).IsModified = true;
                }
            }
            await _context.SaveChangesAsync();

        }
    }
}
