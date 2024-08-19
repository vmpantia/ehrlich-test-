using Microsoft.AspNetCore.Http;
using PizzaPlace.Domain.Models.Entities;
using System.Text;

namespace PizzaPlace.Domain.Extensions
{
    public static class FileExtension
    {
        public static bool IsValidCsvFile(this IFormFile file) =>
            file is IFormFile && Path.GetExtension(file.FileName) == ".csv";

        public static async Task<List<TEntity>> ConvertCsvToObjectsAsync<TEntity>(this IFormFile file)
            where TEntity : class
        {
            // Check if the file is valid a valid Csv file
            if (!file.IsValidCsvFile()) throw new Exception("File is not a valid CSV.");

            var result = new List<TEntity>();
            using (var reader = new StreamReader(file.OpenReadStream()))
            {
                // Skip the first line or the header 
                await reader.ReadLineAsync();

                while (reader.Peek() >= 0)
                {
                    var currentLine = await reader.ReadLineAsync();

                    // Get data based on the TEntity name
                    object newData = typeof(TEntity).Name switch
                    {
                        nameof(Order) => Order.GenerateFromCSVValue(currentLine),
                        nameof(OrderDetail) => OrderDetail.GenerateFromCSVValue(currentLine),
                        nameof(Pizza) => Pizza.GenerateFromCSVValue(currentLine),
                        nameof(PizzaType) => PizzaType.GenerateFromCSVValue(currentLine),
                        _ => throw new ArgumentException("Unsupported Type")
                    };
                    result.Add((TEntity)newData);
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
