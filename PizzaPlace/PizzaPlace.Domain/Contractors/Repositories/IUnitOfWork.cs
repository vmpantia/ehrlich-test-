namespace PizzaPlace.Domain.Contractors.Repositories
{
    public interface IUnitOfWork<TEntity> where TEntity : class
    {
        IBaseRepository<TEntity> Repository { get; }
        Task SaveAsync(CancellationToken token);
    }
}