using MediatR;
using Microsoft.AspNetCore.Http;
using PizzaPlace.Domain.Models.Dtos;

namespace PizzaPlace.Core.Commands.Models
{
    public sealed class ImportPizzaTypesByCSVFileCommand : IRequest<string>
    {
        public ImportPizzaTypesByCSVFileCommand(ImportCsvFileDto dto)
        {
            CsvFile = dto.CsvFile;
        }

        public IFormFile CsvFile { get; init; }
    }
}
