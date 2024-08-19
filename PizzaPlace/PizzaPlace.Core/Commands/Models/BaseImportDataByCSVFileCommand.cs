using MediatR;
using Microsoft.AspNetCore.Http;
using PizzaPlace.Domain.Models.Dtos;

namespace PizzaPlace.Core.Commands.Models
{
    public class BaseImportDataByCSVFileCommand : IRequest<string>
    {
        public BaseImportDataByCSVFileCommand(ImportCsvFileDto dto)
        {
            CsvFile = dto.CsvFile;
        }
        public IFormFile CsvFile { get; init; }
    }
}
