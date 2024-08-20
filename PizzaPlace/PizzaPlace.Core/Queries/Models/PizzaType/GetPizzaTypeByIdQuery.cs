using MediatR;
using PizzaPlace.Domain.Models.Dtos;
using PizzaPlace.Domain.Results;

namespace PizzaPlace.Core.Queries.Models
{
    public record GetPizzaTypeByIdQuery(string Id) : IRequest<Result<PizzaTypeDto>> { }
}
