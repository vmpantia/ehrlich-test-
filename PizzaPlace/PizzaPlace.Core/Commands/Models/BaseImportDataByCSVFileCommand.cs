using MediatR;
using Microsoft.AspNetCore.Http;
using PizzaPlace.Domain.Models.Dtos;
using PizzaPlace.Domain.Results;

namespace PizzaPlace.Core.Commands.Models
{
    public class BaseImportDataByCSVFileCommand : IRequest<Result>
    {
        public BaseImportDataByCSVFileCommand(ImportCsvFileDto dto)
        {
            CsvFile = dto.CsvFile;
        }
        public IFormFile CsvFile { get; init; }
    }
}
