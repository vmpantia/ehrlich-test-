namespace PizzaPlace.Domain.Contractors.Models.Entities
{
    public interface IKeyEntity<TProperty>
    {
        public TProperty Id { get; set; }
    }
}
