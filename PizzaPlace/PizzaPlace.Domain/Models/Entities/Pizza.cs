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
    }
}
