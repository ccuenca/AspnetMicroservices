using AutoMapper;
using Ordering.Applicaction.Features.Orders.Commands.CheckoutOrder;
using Ordering.Applicaction.Features.Orders.Commands.UpdateOrder;
using Ordering.Applicaction.Features.Orders.Queries.GetOrdersList;
using Ordering.Domain.Entities;

namespace Ordering.Applicaction.Mappings
{
  public class MappingProfile : Profile
  {
    public MappingProfile()
    {
      CreateMap<Order, OrdersVm>().ReverseMap();
      CreateMap<Order, CheckoutOrderCommand>().ReverseMap();
      CreateMap<Order, UpdateOrderCommand>().ReverseMap();
    }
  }
}
