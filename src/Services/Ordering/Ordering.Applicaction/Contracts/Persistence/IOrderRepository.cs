using Ordering.Domain.Entities;

namespace Ordering.Applicaction.Contracts.Persistence
{
  public interface IOrderRepository : IAsyncRepository<Order>
  {
    Task<IEnumerable<Order>> GetOrdersByUserName(string userName);
  }

}
