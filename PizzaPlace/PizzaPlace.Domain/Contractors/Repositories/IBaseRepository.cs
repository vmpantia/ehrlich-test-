using System.Linq.Expressions;

namespace PizzaPlace.Domain.Contractors.Repositories
{
    public interface IBaseRepository<TEntity> where TEntity : class
    {
        IQueryable<TEntity> GetAll();
        IQueryable<TEntity> GetByExpression(Expression<Func<TEntity, bool>> expression);
        bool IsExist(Expression<Func<TEntity, bool>> expression, out TEntity entity);
        Task<TEntity> CreateAsync(TEntity entity, CancellationToken token, bool isAutoSave = true);
        Task<TEntity> UpdateAsync(TEntity entity, CancellationToken token, bool isAutoSave = true);
        Task DeleteAsync(TEntity entity, CancellationToken token, bool isAutoSave = true);
    }
}