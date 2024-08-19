using MediatR;
using PizzaPlace.Core.Commands.Models;
using PizzaPlace.Domain.Contractors.Services;
using PizzaPlace.Domain.Extensions;
using PizzaPlace.Domain.Models.Entities;
using PizzaPlace.Domain.Results;

namespace PizzaPlace.Core.Commands.Handlers
{
    public class OrderCommandHandlers :
        IRequestHandler<ImportOrdersByCSVFileCommand, Result>
    {
        private readonly ISynchronizationService<Order, int> _synchronization;
        public OrderCommandHandlers(ISynchronizationService<Order, int> synchronization) =>
            _synchronization = synchronization;

        public async Task<Result> Handle(ImportOrdersByCSVFileCommand request, CancellationToken cancellationToken)
        {
            // Convert csv file to list of order
            var orders = await request.CsvFile.ConvertCsvToObjectsAsync<Order>();

            // Process data synchronization to database
            await _synchronization.DoSyncAsync(orders, cancellationToken);

            return Result.Success("Orders imported successfully to the database.");
        }
    }
}
