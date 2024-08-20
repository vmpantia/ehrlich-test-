namespace PizzaPlace.Domain.Models.Dtos
{
    public class OrderDto
    {
        public required int Id { get; set; }
        public required DateTime CreatedAt { get; set; }
        public decimal NoOfPizzas { get; set; }
        public decimal TotalAmount { get; set; }
        public IEnumerable<OrderDetailDto> Details { get; set; }
    }
}
