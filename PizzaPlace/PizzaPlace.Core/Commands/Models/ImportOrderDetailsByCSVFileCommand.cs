using PizzaPlace.Domain.Models.Dtos;

namespace PizzaPlace.Core.Commands.Models
{
    public sealed class ImportOrderDetailsByCSVFileCommand : BaseImportDataByCSVFileCommand
    {
        public ImportOrderDetailsByCSVFileCommand(ImportCsvFileDto dto) : base(dto) { }
    }
}
