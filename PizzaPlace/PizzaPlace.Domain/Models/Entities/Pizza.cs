using PizzaPlace.Domain.Contractors.Models.Entities;
using System.ComponentModel.DataAnnotations;

namespace PizzaPlace.Domain.Models.Entities
{
    public class Pizza : IKeyEntity<string>
    {
        [Key]
        public required string Id { get; set; }
        public required string PizzaTypeId { get; set; }
        public required string Size { get; set; }
        public required decimal Price { get; set; }

        public virtual PizzaType PizzaType { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }

        public static Pizza GenerateFromCSVValue(string? line)
        {
            // Get values by separating it on comma
            var values = line?.Split(',') ?? [];

            // Check if the values length is valid
            if (values.Length <= 0)
                throw new ArgumentException("Invalid Pizza properties from the CSV.");

            return new Pizza
            {
                Id = values[0],
                PizzaTypeId = values[1],
                Size = values[2],
                Price = decimal.Parse(values[3]),
            };
        }
    }
}
