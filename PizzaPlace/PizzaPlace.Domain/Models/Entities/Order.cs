using PizzaPlace.Domain.Contractors.Models.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PizzaPlace.Domain.Models.Entities
{
    public class Order : IKeyEntity<int>
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public required int Id { get; set; }
        public required DateTime Date { get; set; }
        public required string Time { get; set; }

        public virtual ICollection<OrderDetail> OrderDetails { get; set; }

        public static Order GenerateFromCSVValue(string? line)
        {
            // Get values by separating it on comma
            var values = line?.Split(',') ?? [];

            // Check if the values length is valid
            if (values.Length <= 0)
                throw new ArgumentException("Invalid Order properties from the CSV.");

            return new Order
            {
                Id = int.Parse(values[0]),
                Date = DateTime.Parse(values[1]).Date,
                Time = values[2],
            };
        }
    }
}
