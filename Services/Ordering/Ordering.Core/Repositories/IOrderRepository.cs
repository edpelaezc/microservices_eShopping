using Ordering.Core.Entities;

namespace Ordering.Core.Repositories;

public interface IOrderRepository : IRepositoryBase<Order>
{
    Task<IEnumerable<Order>> GetOrdersByUserName(string userName);
}