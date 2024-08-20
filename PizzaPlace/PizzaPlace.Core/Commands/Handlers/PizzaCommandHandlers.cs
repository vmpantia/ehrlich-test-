using MediatR;
using PizzaPlace.Core.Commands.Models;
using PizzaPlace.Domain.Contractors.Services;
using PizzaPlace.Domain.Extensions;
using PizzaPlace.Domain.Models.Entities;
using PizzaPlace.Domain.Results;

namespace PizzaPlace.Core.Commands.Handlers
{
    public class PizzaCommandHandlers :
        IRequestHandler<ImportPizzasByCSVFileCommand, Result<string>>
    {
        private readonly ISynchronizationService<Pizza, string> _synchronization;
        public PizzaCommandHandlers(ISynchronizationService<Pizza, string> synchronization) =>
            _synchronization = synchronization;

        public async Task<Result<string>> Handle(ImportPizzasByCSVFileCommand request, CancellationToken cancellationToken)
        {
            // Convert csv file to list of pizza
            var pizzas = await request.CsvFile.ConvertCsvToObjectsAsync<Pizza>();

            // Process data synchronization to database
            await _synchronization.DoSyncAsync(pizzas, cancellationToken);

            return Result<string>.Success("Pizzas imported successfully to the database.");
        }
    }
}
