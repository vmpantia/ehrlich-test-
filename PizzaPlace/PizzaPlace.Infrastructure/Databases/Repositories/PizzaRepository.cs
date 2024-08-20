using Microsoft.EntityFrameworkCore;
using PizzaPlace.Domain.Contractors.Repositories;
using PizzaPlace.Domain.Models.Entities;
using PizzaPlace.Infrastructure.Databases.Contexts;

namespace PizzaPlace.Infrastructure.Databases.Repositories
{
    public class PizzaRepository : BaseRepository<Pizza>, IPizzaRepository
    {
        public PizzaRepository(PizzaPlaceDbContext context) : base(context) { }

        public async Task<IEnumerable<Pizza>> GetPizzasAsync() =>
            await GetAll()
                    .Include(tbl => tbl.PizzaType)
                    .ToListAsync();

        public async Task<Pizza?> GetPizzaByIdAsync(string id) =>
            await GetByExpression(data => data.Id.Equals(id))
                    .Include(tbl => tbl.PizzaType)
                    .FirstOrDefaultAsync();
    }
}
