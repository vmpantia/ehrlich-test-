using MediatR;
using PizzaPlace.Domain.Models.Dtos;
using PizzaPlace.Domain.Results;

namespace PizzaPlace.Core.Queries.Models.Pizza
{
    public record GetPizzaByIdQuery(string Id) : IRequest<Result<PizzaDto>> { }
}
