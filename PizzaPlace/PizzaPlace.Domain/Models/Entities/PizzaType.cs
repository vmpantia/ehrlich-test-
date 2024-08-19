using PizzaPlace.Domain.Contractors.Models.Entities;
using PizzaPlace.Domain.Extensions;
using System.ComponentModel.DataAnnotations;

namespace PizzaPlace.Domain.Models.Entities
{
    public class PizzaType : IKeyEntity<string>
    {
        [Key]
        public required string Id { get; set; }
        public required string Name { get; set; }
        public required string Category { get; set; }
        public required string Ingredients { get; set; }

        public virtual ICollection<Pizza> Pizzas { get; set; }

        public static PizzaType GenerateFromCSVValue(string? line)
        {
            // Get values by separating it on comma
            var values = line?.Split(',') ?? [];

            // Check if the values length is valid
            if (values.Length <= 0)
                throw new ArgumentException("Invalid Pizza Type properties from the CSV.");

            return new PizzaType
            {
                Id = values[0],
                Name = values[1],
                Category = values[2],
                Ingredients = values.CombineValuesWithStartIndex(3),
            };
        }
    }
}
