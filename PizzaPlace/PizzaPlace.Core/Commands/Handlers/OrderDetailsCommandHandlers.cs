using MediatR;
using PizzaPlace.Core.Commands.Models;
using PizzaPlace.Domain.Contractors.Services;
using PizzaPlace.Domain.Extensions;
using PizzaPlace.Domain.Models.Entities;

namespace PizzaPlace.Core.Commands.Handlers
{
    public class OrderDetailsCommandHandlers :
        IRequestHandler<ImportOrderDetailsByCSVFileCommand, string>
    {
        private readonly ISynchronizationService<OrderDetail, int> _synchronization;
        public OrderDetailsCommandHandlers(ISynchronizationService<OrderDetail, int> synchronization) =>
            _synchronization = synchronization;

        public async Task<string> Handle(ImportOrderDetailsByCSVFileCommand request, CancellationToken cancellationToken)
        {
            // Convert csv file to list of order detail
            var orderDetails = await request.CsvFile.ConvertCsvToObjectsAsync<OrderDetail>();

            // Process data synchronization to database
            await _synchronization.DoSyncAsync(orderDetails, cancellationToken);

            return "Order details imported successfully to the database.";
        }
    }
}
