using PizzaPlace.Domain.Models.Entities;

namespace PizzaPlace.Domain.Contractors.Repositories
{
    public interface IPizzaRepository
    {
        Task<IEnumerable<Pizza>> GetPizzasAsync();
        Task<Pizza?> GetPizzaByIdAsync(string id);
    }
}