using PizzaPlace.Domain.Contractors.Repositories;
using PizzaPlace.Infrastructure.Databases.Contexts;

namespace PizzaPlace.Infrastructure.Databases.Repositories
{
    public class UnitOfWork<TEntity> : IUnitOfWork<TEntity> where TEntity : class
    {
        private readonly PizzaPlaceDbContext _context;
        public UnitOfWork(PizzaPlaceDbContext context) => _context = context;

        public IBaseRepository<TEntity> Repository => new BaseRepository<TEntity>(_context);
        public async Task SaveAsync(CancellationToken token) => await _context.SaveChangesAsync(token);
    }
}
