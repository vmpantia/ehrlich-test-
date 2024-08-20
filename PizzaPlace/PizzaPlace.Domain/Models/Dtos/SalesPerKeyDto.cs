namespace PizzaPlace.Domain.Models.Dtos
{
    public class SalesPerKeyDto
    {
        public required string Key { get; set; }
        public required int NoOfPizzaSold { get; set; }
        public required decimal TotalAmount { get; set; }
    }
}
