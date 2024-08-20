using MediatR;
using Microsoft.AspNetCore.Mvc;
using PizzaPlace.Core.Queries.Models.Sales;
using PizzaPlace.Domain.Models.Dtos;

namespace PizzaPlace.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalesController : BaseController
    {
        public SalesController(IMediator mediator) : base(mediator) { }

        [HttpGet("categories")]
        public async Task<IActionResult> GetSalesPerCategoryDtoAsync() =>
            await HandleRequestAsync<GetSalesPerCategoryQuery, IEnumerable<SalesPerKeyDto>>(new GetSalesPerCategoryQuery());
        
        [HttpGet("sizes")]
        public async Task<IActionResult> GetSalesPerSizeDtoAsync() =>
            await HandleRequestAsync<GetSalesPerSizeQuery, IEnumerable<SalesPerKeyDto>>(new GetSalesPerSizeQuery());

        [HttpGet("year-month")]
        public async Task<IActionResult> GetSalesPerYearAndMonthDtoAsync() =>
            await HandleRequestAsync<GetSalesPerYearAndMonthQuery, IEnumerable<SalesPerKeyDto>>(new GetSalesPerYearAndMonthQuery());
    }
}
