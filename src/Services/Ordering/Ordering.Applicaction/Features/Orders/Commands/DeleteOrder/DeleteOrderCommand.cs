using MediatR;

namespace Ordering.Applicaction.Features.Orders.Commands.DeleteOrder
{
  public class DeleteOrderCommand : IRequest
  {
    public int Id { get; set; }
  }

}
