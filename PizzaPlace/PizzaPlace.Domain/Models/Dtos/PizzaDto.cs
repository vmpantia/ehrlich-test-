using PizzaPlace.Domain.Models.Lites;

namespace PizzaPlace.Domain.Models.Dtos
{
    public class PizzaDto
    {
        public required string Id { get; set; }
        public required string Size { get; set; }
        public required decimal Price { get; set; }
        public required PizzaTypeLite Type { get; set; }
    }
}
