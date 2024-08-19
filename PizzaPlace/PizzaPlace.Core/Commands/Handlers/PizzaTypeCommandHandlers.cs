using MediatR;
using PizzaPlace.Core.Commands.Models;
using PizzaPlace.Domain.Contractors.Services;
using PizzaPlace.Domain.Extensions;
using PizzaPlace.Domain.Models.Entities;
using System.Text;

namespace PizzaPlace.Core.Commands.Handlers
{
    public sealed class PizzaTypeCommandHandlers :
        IRequestHandler<ImportPizzaTypesByCSVFileCommand, string>
    {
        private readonly ISynchronizationService<PizzaType, string> _synchronization;
        public PizzaTypeCommandHandlers(ISynchronizationService<PizzaType, string> synchronization)
        {
            _synchronization = synchronization;
        }

        public async Task<string> Handle(ImportPizzaTypesByCSVFileCommand request, CancellationToken cancellationToken)
        {
            // Convert csv file to list of pizze type
            var pizzaTypes = await request.CsvFile.ConvertCsvToPizzaTypesAsync();

            // Process data synchronization to database
            await _synchronization.DoSyncAsync(pizzaTypes, cancellationToken);

            return "Pizza Types imported successfully to the database.";
        }
    }
}
