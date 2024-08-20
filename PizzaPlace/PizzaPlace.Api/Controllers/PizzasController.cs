using MediatR;
using Microsoft.AspNetCore.Mvc;
using PizzaPlace.Core.Queries.Models;
using PizzaPlace.Core.Queries.Models.Pizza;
using PizzaPlace.Domain.Models.Dtos;

namespace PizzaPlace.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PizzasController : BaseController
    {
        public PizzasController(IMediator mediator) : base(mediator) { }

        [HttpGet]
        public async Task<IActionResult> GetPizzasDtoAsync() =>
            await HandleRequestAsync<GetAllPizzasQuery, IEnumerable<PizzaDto>>(new GetAllPizzasQuery());

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPizzaByIdDtoAsync(string id) =>
            await HandleRequestAsync<GetPizzaByIdQuery, PizzaDto>(new GetPizzaByIdQuery(id));

        [HttpGet("types")]
        public async Task<IActionResult> GetPizzaTypesDtoAsync() =>
            await HandleRequestAsync<GetAllPizzaTypesQuery, IEnumerable<PizzaTypeDto>>(new GetAllPizzaTypesQuery());

        [HttpGet("types/{id}")]
        public async Task<IActionResult> GetPizzaTypeByIdDtoAsync(string id) =>
            await HandleRequestAsync<GetPizzaTypeByIdQuery, PizzaTypeDto>(new GetPizzaTypeByIdQuery(id));
    }
}
