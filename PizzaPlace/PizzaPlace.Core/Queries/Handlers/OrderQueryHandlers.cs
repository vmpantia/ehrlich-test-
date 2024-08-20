using AutoMapper;
using MediatR;
using PizzaPlace.Core.Queries.Models.Order;
using PizzaPlace.Domain.Contractors.Repositories;
using PizzaPlace.Domain.Models.Dtos;
using PizzaPlace.Domain.Models.Entities;
using PizzaPlace.Domain.Results;
using PizzaPlace.Domain.Results.Errors;

namespace PizzaPlace.Core.Queries.Handlers
{
    public sealed class OrderQueryHandlers :
        IRequestHandler<GetOrdersByPaginationQuery, Result<IEnumerable<OrderDto>>>,
        IRequestHandler<GetOrderByIdQuery, Result<OrderDto>>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;
        public OrderQueryHandlers(IOrderRepository orderRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
        }

        public async Task<Result<IEnumerable<OrderDto>>> Handle(GetOrdersByPaginationQuery request, CancellationToken cancellationToken)
        {
            // Get all orders stored in the database
            var orders = await _orderRepository.GetOrdersAsync(request.PageNumber, request.PageSize);

            // Convert entity to dto
            var result = _mapper.Map<IEnumerable<OrderDto>>(orders);

            return Result<IEnumerable<OrderDto>>.Success(result);
        }

        public async Task<Result<OrderDto>> Handle(GetOrderByIdQuery request, CancellationToken cancellationToken)
        {
            // Get order stored in the database using Id
            var order = await _orderRepository.GetOrderByIdAsync(request.Id);

            // Check if the order is found in the database
            if (order is not Order)
                return Result<OrderDto>.Failure(CommonError.NotFoundById<GetOrderByIdQuery, Order>(request.Id.ToString()));

            // Convert entity to dto
            var result = _mapper.Map<OrderDto>(order);

            return Result<OrderDto>.Success(result);
        }
    }
}
