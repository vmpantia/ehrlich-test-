using MediatR;
using Microsoft.AspNetCore.Mvc;
using PizzaPlace.Core.Commands.Models;
using PizzaPlace.Domain.Models.Dtos;

namespace PizzaPlace.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DataController : BaseController
    {
        public DataController(IMediator mediator) : base(mediator) { }

        [HttpPost("import/orders")]
        public async Task<IActionResult> ImpordOrders([FromForm] ImportCsvFileDto request) =>
            await HandleRequestAsync<ImportOrdersByCSVFileCommand, string>(new ImportOrdersByCSVFileCommand(request));

        [HttpPost("import/order-details")]
        public async Task<IActionResult> ImpordOrderDetails([FromForm] ImportCsvFileDto request) =>
            await HandleRequestAsync<ImportOrderDetailsByCSVFileCommand, string>(new ImportOrderDetailsByCSVFileCommand(request));

        [HttpPost(template: "import/pizzas")]
        public async Task<IActionResult> ImportPizzas([FromForm] ImportCsvFileDto request) =>
            await HandleRequestAsync<ImportPizzasByCSVFileCommand, string>(new ImportPizzasByCSVFileCommand(request));

        [HttpPost("import/pizza-types")]
        public async Task<IActionResult> ImportPizzaTypes([FromForm] ImportCsvFileDto request) =>
            await HandleRequestAsync<ImportPizzaTypesByCSVFileCommand, string>(new ImportPizzaTypesByCSVFileCommand(request));
    }
}
