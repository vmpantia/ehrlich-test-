using AutoMapper;
using MediatR;
using PizzaPlace.Core.Queries.Models.Pizza;
using PizzaPlace.Domain.Contractors.Repositories;
using PizzaPlace.Domain.Models.Dtos;
using PizzaPlace.Domain.Models.Entities;
using PizzaPlace.Domain.Results;
using PizzaPlace.Domain.Results.Errors;

namespace PizzaPlace.Core.Queries.Handlers
{
    public sealed class PizzaQueryHandlers :
        IRequestHandler<GetAllPizzasQuery, Result<IEnumerable<PizzaDto>>>,
        IRequestHandler<GetPizzaByIdQuery, Result<PizzaDto>>
    {
        private readonly IPizzaRepository _pizzaRepository;
        private readonly IMapper _mapper;
        public PizzaQueryHandlers(IPizzaRepository pizzaRepository, IMapper mapper)
        {
            _pizzaRepository = pizzaRepository;
            _mapper = mapper;
        }

        public async Task<Result<IEnumerable<PizzaDto>>> Handle(GetAllPizzasQuery request, CancellationToken cancellationToken)
        {
            // Get all pizzas stored in the database
            var pizzas = await _pizzaRepository.GetPizzasAsync();

            // Convert entity to dto
            var result = _mapper.Map<IEnumerable<PizzaDto>>(pizzas);

            return Result<IEnumerable<PizzaDto>>.Success(result);
        }

        public async Task<Result<PizzaDto>> Handle(GetPizzaByIdQuery request, CancellationToken cancellationToken)
        {
            // Get pizza stored in the database using Id
            var pizza = await _pizzaRepository.GetPizzaByIdAsync(request.Id);

            // Check if the pizza is found in the database
            if (pizza is not Pizza) 
                return Result<PizzaDto>.Failure(CommonError.NotFoundById<GetPizzaByIdQuery, Pizza>(request.Id));

            // Convert entity to dto
            var result = _mapper.Map<PizzaDto>(pizza);

            return Result<PizzaDto>.Success(result);
        }
    }
}
