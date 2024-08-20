using PizzaPlace.Domain.Contractors.Models.Entities;

namespace PizzaPlace.Domain.Contractors.Services
{
    public interface ISynchronizationService<TEntity, TKeyProperty> where TEntity : class, IKeyEntity<TKeyProperty>
    {
        Task DoSyncAsync(IEnumerable<TEntity> entities, CancellationToken token);
    }
}