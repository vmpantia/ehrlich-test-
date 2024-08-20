using Microsoft.AspNetCore.Http;

namespace PizzaPlace.Domain.Models.Dtos
{
    public class ImportCsvFileDto
    {
        public IFormFile CsvFile { get; set; }
    }
}
