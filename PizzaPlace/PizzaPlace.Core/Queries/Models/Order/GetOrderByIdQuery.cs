using MediatR;
using PizzaPlace.Domain.Models.Dtos;
using PizzaPlace.Domain.Results;

namespace PizzaPlace.Core.Queries.Models.Order
{
    public record GetOrderByIdQuery(int Id) : IRequest<Result<OrderDto>> { }
}
