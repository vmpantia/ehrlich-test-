using AutoMapper;
using PizzaPlace.Domain.Models.Entities;

namespace PizzaPlace.Core.Mappings
{
    public class EntityProfiles : Profile
    {
        public EntityProfiles()
        {
            CreateMap<Order, Order>()
                .ForMember(dst => dst.Id, opt => opt.Ignore());
            CreateMap<OrderDetail, OrderDetail>()
                .ForMember(dst => dst.Id, opt => opt.Ignore());
            CreateMap<Pizza, Pizza>()
                .ForMember(dst => dst.Id, opt => opt.Ignore());
            CreateMap<PizzaType, PizzaType>()
                .ForMember(dst => dst.Id, opt => opt.Ignore());
        }
    }
}
