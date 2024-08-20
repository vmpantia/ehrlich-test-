using MediatR;
using PizzaPlace.Domain.Models.Dtos;
using PizzaPlace.Domain.Results;

namespace PizzaPlace.Core.Queries.Models.Sales
{
    public record GetSalesPerSizeQuery() : IRequest<Result<IEnumerable<SalesPerKeyDto>>> { }
}
