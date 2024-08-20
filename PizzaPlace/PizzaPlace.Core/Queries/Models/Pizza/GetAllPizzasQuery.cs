using MediatR;
using PizzaPlace.Domain.Models.Dtos;
using PizzaPlace.Domain.Results;

namespace PizzaPlace.Core.Queries.Models.Pizza
{
    public class GetAllPizzasQuery : IRequest<Result<IEnumerable<PizzaDto>>> { }
}
