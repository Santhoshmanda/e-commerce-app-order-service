using AutoMapper;
using OGANI.OrderService.Infrastructure.Entities;
using Models = OGANI.OrderService.Domain.Models;

namespace OGANI.OrderService.Infrastructure.MappingProfiles
{
    public class OrderProfile:Profile
	{
		public OrderProfile()
		{
			CreateMap<Models.Order,Order>()
			.ForMember(dest => dest.OrderItems, opt => opt.MapFrom(src => src.OrderItems))
              .ForMember(dest => dest.OrderStatuses, opt => opt.MapFrom(src => src.OrderItems));
            CreateMap<Order, Models.Order>()
			  .ForMember(dest => dest.OrderItems, opt => opt.MapFrom(src => src.OrderItems))
              .ForMember(dest => dest.OrderStatuses, opt => opt.MapFrom(src => src.OrderItems));
            CreateMap<Models.OrderItem, OrderItem>().ReverseMap();
        }
	}
}