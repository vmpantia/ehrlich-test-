using AutoMapper;
using PizzaPlace.Domain.Models.Dtos;
using PizzaPlace.Domain.Models.Entities;
using PizzaPlace.Domain.Models.Lites;

namespace PizzaPlace.Core.Mappings
{
    public class EntityProfiles : Profile
    {
        public EntityProfiles()
        {;

            CreateMap<Order, Order>()
                .ForMember(dst => dst.Id, opt => opt.Ignore());
            CreateMap<Order, OrderDto>()
                .ForMember(dst => dst.CreatedAt, opt => opt.MapFrom(src => src.Date))
                .ForMember(dst => dst.NoOfPizzas, opt => opt.MapFrom(src => src.OrderDetails.Select(data => data.PizzaId).Distinct().Count()))
                .ForMember(dst => dst.TotalAmount, opt => opt.MapFrom(src => src.OrderDetails.Sum(data => data.Quantity * data.Pizza.Price)))
                .ForMember(dst => dst.Details, opt => opt.MapFrom(src => src.OrderDetails));

            CreateMap<OrderDetail, OrderDetail>()
                .ForMember(dst => dst.Id, opt => opt.Ignore());
            CreateMap<OrderDetail, OrderDetailDto>()
                .ForMember(dst => dst.Amount, opt => opt.MapFrom(src => src.Quantity * src.Pizza.Price));

            CreateMap<Pizza, Pizza>()
                .ForMember(dst => dst.Id, opt => opt.Ignore());
            CreateMap<Pizza, PizzaDto>()
                .ForMember(dst => dst.Type, opt => opt.MapFrom(src => src.PizzaType));

            CreateMap<PizzaType, PizzaType>()
                .ForMember(dst => dst.Id, opt => opt.Ignore());
            CreateMap<PizzaType, PizzaTypeDto>()
                .ForMember(dst => dst.NoOfPizzas, opt => opt.MapFrom(src => src.Pizzas.Count()));
            CreateMap<PizzaType, PizzaTypeLite>();
        }
    }
}
