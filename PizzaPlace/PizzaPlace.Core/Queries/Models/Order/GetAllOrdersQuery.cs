using MediatR;
using PizzaPlace.Domain.Models.Dtos;
using PizzaPlace.Domain.Results;

namespace PizzaPlace.Core.Queries.Models.Order
{
    public record GetOrdersByPaginationQuery(int PageNumber, int PageSize) : IRequest<Result<IEnumerable<OrderDto>>> { }
}
