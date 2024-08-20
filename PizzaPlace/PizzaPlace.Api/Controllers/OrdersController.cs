using MediatR;
using Microsoft.AspNetCore.Mvc;
using PizzaPlace.Core.Queries.Models.Order;
using PizzaPlace.Domain.Models.Dtos;

namespace PizzaPlace.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : BaseController
    {
        public OrdersController(IMediator mediator) : base(mediator) { }

        [HttpGet]
        public async Task<IActionResult> GetOrdersDtoAsync([FromQuery] PaginationDto pagination) =>
            await HandleRequestAsync<GetOrdersByPaginationQuery, IEnumerable<OrderDto>>(new GetOrdersByPaginationQuery(pagination.PageNumber, pagination.PageSize));

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrderByIdDtoAsync(int id) =>
            await HandleRequestAsync<GetOrderByIdQuery, OrderDto>(new GetOrderByIdQuery(id));
    }
}
