using Microsoft.EntityFrameworkCore;
using PizzaPlace.Domain.Contractors.Repositories;
using PizzaPlace.Infrastructure.Databases.Contexts;
using System.Linq.Expressions;

namespace PizzaPlace.Infrastructure.Databases.Repositories
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> 
        where TEntity : class
    {
        protected readonly PizzaPlaceDbContext _context;
        protected readonly DbSet<TEntity> _table;
        public BaseRepository(PizzaPlaceDbContext context)
        {
            _context = context;
            _table = context.Set<TEntity>();
        }

        public IQueryable<TEntity> GetAll() => _table;

        public IQueryable<TEntity> GetByExpression(Expression<Func<TEntity, bool>> expression) => _table.Where(expression);

        public bool IsExist(Expression<Func<TEntity, bool>> expression, out TEntity entity)
        {
            entity = _table.FirstOrDefault(expression);
            return entity is not TEntity;
        }

        public async Task<TEntity> CreateAsync(TEntity entity, CancellationToken token, bool isAutoSave = true)
        {
            await _table.AddAsync(entity, token);
            if(isAutoSave) await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<TEntity> UpdateAsync(TEntity entity, CancellationToken token, bool isAutoSave = true)
        {
            _table.Update(entity);
            if (isAutoSave) await _context.SaveChangesAsync();
            return entity;
        }

        public async Task DeleteAsync(TEntity entity, CancellationToken token, bool isAutoSave = true)
        {
            _table.Remove(entity);
            if (isAutoSave) await _context.SaveChangesAsync();
        }
    }
}
