using MediatR;
using Microsoft.AspNetCore.Mvc;
using PizzaPlace.Core.Commands.Models;
using PizzaPlace.Domain.Models.Dtos;

namespace PizzaPlace.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PizzasController : ControllerBase
    {
        private readonly IMediator _mediator;
        public PizzasController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("import")]
        public async Task<IActionResult> ImportPizzas([FromForm] ImportCsvFileDto request)
        {
            var result = await _mediator.Send(new ImportPizzasByCSVFileCommand(request));
            return Ok(result);
        }

        [HttpPost("types/import")]
        public async Task<IActionResult> ImportPizzaTypes([FromForm] ImportCsvFileDto request)
        {
            var result = await _mediator.Send(new ImportPizzaTypesByCSVFileCommand(request));
            return Ok(result);
        }
    }
}
