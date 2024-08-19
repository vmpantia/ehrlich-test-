using MediatR;
using Microsoft.AspNetCore.Mvc;
using PizzaPlace.Core.Commands.Models;
using PizzaPlace.Domain.Models.Dtos;

namespace PizzaPlace.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PizzaController : ControllerBase
    {
        private readonly IMediator _mediator;
        public PizzaController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("types/import")]
        public async Task<IActionResult> ImportPizzaTypes([FromForm] ImportCsvFileDto request)
        {
            var result = await _mediator.Send(new ImportPizzaTypesByCSVFileCommand(request));
            return Ok(result);
        }
    }
}
