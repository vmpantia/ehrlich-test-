using PizzaPlace.Domain.Models.Entities;

namespace PizzaPlace.Domain.Contractors.Repositories
{
    public interface IPizzaTypeRepository : IBaseRepository<PizzaType>
    {
        Task<IEnumerable<PizzaType>> GetPizzaTypesAsync();
        Task<PizzaType?> GetPizzaTypeByIdAsync(string id);
    }
}