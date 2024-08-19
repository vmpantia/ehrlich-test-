using MediatR;
using Microsoft.AspNetCore.Mvc;
using PizzaPlace.Core.Commands.Models;
using PizzaPlace.Domain.Models.Dtos;

namespace PizzaPlace.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IMediator _mediator;
        public OrdersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("import")]
        public async Task<IActionResult> ImpordOrders([FromForm] ImportCsvFileDto request)
        {
            var result = await _mediator.Send(new ImportOrdersByCSVFileCommand(request));
            return Ok(result);
        }

        [HttpPost("details/import")]
        public async Task<IActionResult> ImpordOrderDetails([FromForm] ImportCsvFileDto request)
        {
            var result = await _mediator.Send(new ImportOrderDetailsByCSVFileCommand(request));
            return Ok(result);
        }
    }
}
