using PizzaPlace.Domain.Models.Enums;

namespace PizzaPlace.Domain.Models.Sync
{
    public sealed record DataSync<TKeyProperty>(SyncAction Action, TKeyProperty Id) { }
}
