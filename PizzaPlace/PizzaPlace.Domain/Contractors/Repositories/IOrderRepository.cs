using PizzaPlace.Domain.Models.Entities;

namespace PizzaPlace.Domain.Contractors.Repositories
{
    public interface IOrderRepository : IBaseRepository<Order>
    {
        Task<Order?> GetOrderByIdAsync(int id);
        Task<IEnumerable<Order>> GetOrdersAsync(int pageNumber, int pageSize);
    }
}