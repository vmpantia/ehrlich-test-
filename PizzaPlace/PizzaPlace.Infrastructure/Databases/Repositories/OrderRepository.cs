using Microsoft.EntityFrameworkCore;
using PizzaPlace.Domain.Contractors.Repositories;
using PizzaPlace.Domain.Models.Entities;
using PizzaPlace.Infrastructure.Databases.Contexts;

namespace PizzaPlace.Infrastructure.Databases.Repositories
{
    public class OrderRepository : BaseRepository<Order>, IOrderRepository
    {
        public OrderRepository(PizzaPlaceDbContext context) : base(context) { }

        public async Task<IEnumerable<Order>> GetOrdersAsync(int pageNumber, int pageSize) =>
            await GetAll()
                    .Include(tbl => tbl.OrderDetails)
                        .ThenInclude(tbl => tbl.Pizza)
                            .ThenInclude(tbl => tbl.PizzaType)
                    .AsSplitQuery()
                    .OrderByDescending(data => data.Date)
                    .Skip(pageNumber - 1)
                    .Take(pageSize)
                    .ToListAsync();

        public async Task<Order?> GetOrderByIdAsync(int id) =>
            await GetByExpression(data => data.Id == id)
                    .Include(tbl => tbl.OrderDetails)
                        .ThenInclude(tbl => tbl.Pizza)
                            .ThenInclude(tbl => tbl.PizzaType)
                    .AsSplitQuery()
                    .FirstOrDefaultAsync();
    }
}
