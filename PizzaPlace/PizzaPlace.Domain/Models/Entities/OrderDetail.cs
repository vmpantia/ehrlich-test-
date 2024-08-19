using PizzaPlace.Domain.Contractors.Models.Entities;
using System.ComponentModel.DataAnnotations;

namespace PizzaPlace.Domain.Models.Entities
{
    public class OrderDetail : IKeyEntity<int>
    {
        [Key]
        public required int Id { get; set; }
        public required int OrderId { get; set; } 
        public required string PizzaId { get; set; } 
        public required int Quantity { get; set; } 

        public required virtual Order Order { get; set; }
        public required virtual Pizza Pizza { get; set; }
    }
}
