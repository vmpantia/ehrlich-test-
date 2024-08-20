using AutoMapper;
using MediatR;
using PizzaPlace.Core.Queries.Models;
using PizzaPlace.Domain.Contractors.Repositories;
using PizzaPlace.Domain.Models.Dtos;
using PizzaPlace.Domain.Models.Entities;
using PizzaPlace.Domain.Results;
using PizzaPlace.Domain.Results.Errors;

namespace PizzaPlace.Core.Queries.Handlers
{
    public sealed class PizzaTypeQueryHandlers :
        IRequestHandler<GetAllPizzaTypesQuery, Result<IEnumerable<PizzaTypeDto>>>,
        IRequestHandler<GetPizzaTypeByIdQuery, Result<PizzaTypeDto>>
    {
        private readonly IPizzaTypeRepository _pizzaTypeRepository;
        private readonly IMapper _mapper;
        public PizzaTypeQueryHandlers(IPizzaTypeRepository pizzaTypeRepository, IMapper mapper)
        {
            _pizzaTypeRepository = pizzaTypeRepository;
            _mapper = mapper;
        }

        public async Task<Result<IEnumerable<PizzaTypeDto>>> Handle(GetAllPizzaTypesQuery request, CancellationToken cancellationToken)
        {
            // Get all pizzas stored in the database
            var pizzas = await _pizzaTypeRepository.GetPizzaTypesAsync();

            // Convert entity to dto
            var result = _mapper.Map<IEnumerable<PizzaTypeDto>>(pizzas);

            return Result<IEnumerable<PizzaTypeDto>>.Success(result);
        }

        public async Task<Result<PizzaTypeDto>> Handle(GetPizzaTypeByIdQuery request, CancellationToken cancellationToken)
        {
            // Get pizza type stored in the database using Id
            var pizzaType = await _pizzaTypeRepository.GetPizzaTypeByIdAsync(request.Id);

            // Check if the pizza type is found in the database
            if (pizzaType is not PizzaType) 
                return Result<PizzaTypeDto>.Failure(CommonError.NotFoundById<GetPizzaTypeByIdQuery, PizzaType>(request.Id));

            // Convert entity to dto
            var result = _mapper.Map<PizzaTypeDto>(pizzaType);

            return Result<PizzaTypeDto>.Success(result);
        }
    }
}
