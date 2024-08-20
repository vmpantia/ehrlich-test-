using MediatR;
using PizzaPlace.Domain.Models.Dtos;
using PizzaPlace.Domain.Results;

namespace PizzaPlace.Core.Queries.Models
{
    public class GetAllPizzaTypesQuery : IRequest<Result<IEnumerable<PizzaTypeDto>>> { }
}
