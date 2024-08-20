using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PizzaPlace.Core.Queries.Models.Sales;
using PizzaPlace.Domain.Contractors.Repositories;
using PizzaPlace.Domain.Models.Dtos;
using PizzaPlace.Domain.Models.Entities;
using PizzaPlace.Domain.Results;

namespace PizzaPlace.Core.Queries.Handlers
{
    public sealed class SalesQueryHandlers :
        IRequestHandler<GetSalesPerCategoryQuery, Result<IEnumerable<SalesPerKeyDto>>>,
        IRequestHandler<GetSalesPerSizeQuery, Result<IEnumerable<SalesPerKeyDto>>>,
        IRequestHandler<GetSalesPerYearAndMonthQuery, Result<IEnumerable<SalesPerKeyDto>>>
    {
        private readonly IPizzaTypeRepository _pizzaTypeRepository;
        private readonly IPizzaRepository _pizzaRepository;
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;
        public SalesQueryHandlers(IPizzaTypeRepository pizzaTypeRepository, IPizzaRepository pizzaRepository, IOrderRepository orderRepository, IMapper mapper)
        {
            _pizzaTypeRepository = pizzaTypeRepository;
            _pizzaRepository = pizzaRepository;
            _orderRepository = orderRepository;
            _mapper = mapper;
        }

        public async Task<Result<IEnumerable<SalesPerKeyDto>>> Handle(GetSalesPerCategoryQuery request, CancellationToken cancellationToken)
        {
            // Get all pizza types
            var pizzaTypes = await _pizzaTypeRepository.GetAll()
                                                       .Include(tbl => tbl.Pizzas)
                                                              .ThenInclude(tbl => tbl.OrderDetails)
                                                       .AsSplitQuery()
                                                       .ToListAsync();

            // Get sales per category
            var result = pizzaTypes.GroupBy(data => data.Category)
                                   .Select(ptg => new SalesPerKeyDto
                                   {
                                       Key = ptg.Key,
                                       NoOfPizzaSold = ptg.Sum(pt => pt.Pizzas.Sum(pz => pz.OrderDetails.Count())),
                                       TotalAmount = ptg.Sum(pt => pt.Pizzas.Sum(pz => pz.OrderDetails.Sum(od => od.Quantity) * pz.Price)),
                                   })
                                   .ToList();

            return Result<IEnumerable<SalesPerKeyDto>>.Success(result);
        }

        public async Task<Result<IEnumerable<SalesPerKeyDto>>> Handle(GetSalesPerSizeQuery request, CancellationToken cancellationToken)
        {
            // Get all pizzas
            var pizzas = await _pizzaRepository.GetAll()
                                               .Include(tbl => tbl.OrderDetails)
                                               .ToListAsync();

            // Get sales per size
            var result = pizzas.GroupBy(data => data.Size)
                               .Select(pzg => new SalesPerKeyDto
                               {
                                   Key = pzg.Key,
                                   NoOfPizzaSold = pzg.Sum(pz => pz.OrderDetails.Count()),
                                   TotalAmount = pzg.Sum(pz => pz.OrderDetails.Sum(od => od.Quantity) * pz.Price),
                               })
                               .ToList();

            return Result<IEnumerable<SalesPerKeyDto>>.Success(result);
        }

        public async Task<Result<IEnumerable<SalesPerKeyDto>>> Handle(GetSalesPerYearAndMonthQuery request, CancellationToken cancellationToken)
        {
            // Get all orders
            var orders = await _orderRepository.GetAll()
                                               .Include(tbl => tbl.OrderDetails)   
                                                    .ThenInclude(tbl => tbl.Pizza)
                                               .ToListAsync();

            // Get sales per day of week
            var result = orders.GroupBy(data => new { data.Date.Year, data.Date.Month })
                               .Select(o => new SalesPerKeyDto
                               {
                                   Key = $"{o.Key.Year}-{o.Key.Month}",
                                   NoOfPizzaSold = o.Sum(pz => pz.OrderDetails.Count()),
                                   TotalAmount = o.Sum(pz => pz.OrderDetails.Sum(od => od.Quantity * od.Pizza.Price)),
                               })
                               .ToList();

            return Result<IEnumerable<SalesPerKeyDto>>.Success(result);
        }
    }
}
