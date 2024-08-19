using PizzaPlace.Domain.Models.Dtos;

namespace PizzaPlace.Core.Commands.Models
{
    public sealed class ImportPizzasByCSVFileCommand : BaseImportDataByCSVFileCommand
    {
        public ImportPizzasByCSVFileCommand(ImportCsvFileDto dto) : base(dto) { }
    }
}
