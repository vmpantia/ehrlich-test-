using PizzaPlace.Domain.Contractors.Models.Entities;
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

        public virtual ICollection<PizzaType> Pizzas { get; set; }
    }
}
