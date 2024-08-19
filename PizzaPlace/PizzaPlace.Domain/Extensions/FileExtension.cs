using Microsoft.AspNetCore.Http;
using PizzaPlace.Domain.Models.Entities;
using System.Text;
using System.Xml.Linq;

namespace PizzaPlace.Domain.Extensions
{
    public static class FileExtension
    {
        public static bool IsValidCsvFile(this IFormFile file) =>
            file is IFormFile && Path.GetExtension(file.FileName) == ".csv";

        public static async Task<List<PizzaType>> ConvertCsvToPizzaTypesAsync(this IFormFile file)
        {
            // Check if the file is valid a valid Csv file
            if (!file.IsValidCsvFile()) throw new Exception("File is not a valid CSV.");

            var result = new List<PizzaType>();
            using (var reader = new StreamReader(file.OpenReadStream()))
            {
                // Skip the first line or the header 
                await reader.ReadLineAsync();

                while (reader.Peek() >= 0)
                {
                    var currentLine = await reader.ReadLineAsync();
                    var pizzaType = PizzaType.GenerateFromCSVValue(currentLine);
                    result.Add(pizzaType);
                }
            }

            return result;
        }

        public static string CombineValuesWithStartIndex(this string[] values, int startIndex)
        {
            if (startIndex < 0 || startIndex > values.Length)
                throw new ArgumentOutOfRangeException(nameof(startIndex));

            var builder = new StringBuilder();
            for(var index = startIndex; index < values.Length; index++)
            {
                builder.Append(values[index]);
            }

            return builder.ToString();
        }
    }
}
