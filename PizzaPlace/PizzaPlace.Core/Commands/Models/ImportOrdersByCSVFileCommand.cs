using PizzaPlace.Domain.Models.Dtos;

namespace PizzaPlace.Core.Commands.Models
{
    public sealed class ImportOrdersByCSVFileCommand : BaseImportDataByCSVFileCommand
    {
        public ImportOrdersByCSVFileCommand(ImportCsvFileDto dto) : base(dto) { }
    }
}
