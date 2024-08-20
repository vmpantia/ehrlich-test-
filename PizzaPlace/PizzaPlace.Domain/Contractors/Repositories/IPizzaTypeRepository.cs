using PizzaPlace.Domain.Models.Entities;

namespace PizzaPlace.Domain.Contractors.Repositories
{
    public interface IPizzaTypeRepository
    {
        Task<IEnumerable<PizzaType>> GetPizzaTypesAsync();
        Task<PizzaType?> GetPizzaTypeByIdAsync(string id);
    }
}