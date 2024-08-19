using PizzaPlace.Domain.Contractors.Models.Entities;
using System.ComponentModel.DataAnnotations;

namespace PizzaPlace.Domain.Models.Entities
{
    public class Order : IKeyEntity<int>
    {
        [Key]
        public required int Id { get; set; }
        public required string Date { get; set; }
        public required string Time { get; set; }

        public virtual ICollection<OrderDetail> Details { get; set; }
    }
}
