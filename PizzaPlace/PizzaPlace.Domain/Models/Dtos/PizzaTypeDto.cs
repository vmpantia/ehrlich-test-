using PizzaPlace.Domain.Models.Lites;

namespace PizzaPlace.Domain.Models.Dtos
{
    public class PizzaTypeDto : PizzaTypeLite
    {
        public required int NoOfPizzas { get; set; }
    }
}
