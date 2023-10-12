using Ordering.Core.Repositories;
using Ordering.Infrastructure.Data;

namespace Ordering.Infrastructure.Repositories;

public class RepositoryManager : IRepositoryManager
{
    private readonly OrderContext _context;
    private readonly Lazy<IOrderRepository> _order;

    public RepositoryManager(OrderContext context)
    {
        _context = context;
        _order = new Lazy<IOrderRepository>(() => new OrderRepository(context));
    }

    public async Task SaveAsync()
    {
        await _context.SaveChangesAsync();
    }

    public IOrderRepository Order => _order.Value;
}