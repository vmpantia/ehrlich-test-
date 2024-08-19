using PizzaPlace.Domain.Contractors.Models.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PizzaPlace.Domain.Models.Entities
{
    public class OrderDetail : IKeyEntity<int>
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public required int Id { get; set; }
        public required int OrderId { get; set; } 
        public required string PizzaId { get; set; } 
        public required int Quantity { get; set; } 

        public virtual Order Order { get; set; }
        public virtual Pizza Pizza { get; set; }

        public static OrderDetail GenerateFromCSVValue(string? line)
        {
            // Get values by separating it on comma
            var values = line?.Split(',') ?? [];

            // Check if the values length is valid
            if (values.Length <= 0)
                throw new ArgumentException("Invalid Order Detail properties from the CSV.");

            return new OrderDetail
            {
                Id = int.Parse(values[0]),
                OrderId = int.Parse(values[1]),
                PizzaId = values[2],
                Quantity = int.Parse(values[3]),
            };
        }
    }
}
