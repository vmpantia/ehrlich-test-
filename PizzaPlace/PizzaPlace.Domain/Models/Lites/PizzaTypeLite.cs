namespace PizzaPlace.Domain.Models.Lites
{
    public class PizzaTypeLite
    {
        public required string Id { get; set; }
        public required string Name { get; set; }
        public required string Category { get; set; }
        public required string Ingredients { get; set; }
    }
}
