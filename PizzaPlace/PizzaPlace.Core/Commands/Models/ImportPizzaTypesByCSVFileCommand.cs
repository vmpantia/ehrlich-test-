using PizzaPlace.Domain.Models.Dtos;

namespace PizzaPlace.Core.Commands.Models
{
    public sealed class ImportPizzaTypesByCSVFileCommand : BaseImportDataByCSVFileCommand
    {
        public ImportPizzaTypesByCSVFileCommand(ImportCsvFileDto dto) : base(dto) { }
    }
}
