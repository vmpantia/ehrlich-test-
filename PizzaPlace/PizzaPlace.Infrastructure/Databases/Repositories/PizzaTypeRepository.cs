using Microsoft.EntityFrameworkCore;
using PizzaPlace.Domain.Contractors.Repositories;
using PizzaPlace.Domain.Models.Entities;
using PizzaPlace.Infrastructure.Databases.Contexts;

namespace PizzaPlace.Infrastructure.Databases.Repositories
{
    public class PizzaTypeRepository : BaseRepository<PizzaType>, IPizzaTypeRepository
    {
        public PizzaTypeRepository(PizzaPlaceDbContext context) : base(context) { }

        public async Task<IEnumerable<PizzaType>> GetPizzaTypesAsync() =>
            await GetAll()
                    .Include(tbl => tbl.Pizzas)
                    .ToListAsync();

        public async Task<PizzaType?> GetPizzaTypeByIdAsync(string id) =>
            await GetByExpression(data => data.Id.Equals(id))
                    .Include(tbl => tbl.Pizzas)
                    .FirstOrDefaultAsync();
    }
}
