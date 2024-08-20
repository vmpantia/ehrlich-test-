namespace PizzaPlace.Domain.Models.Dtos
{
    public class OrderDetailDto
    {
        public required int Id { get; set; }
        public required int Quantity { get; set; }
        public required PizzaDto Pizza { get; set; }
        public decimal Amount { get; set; }
    }
}
