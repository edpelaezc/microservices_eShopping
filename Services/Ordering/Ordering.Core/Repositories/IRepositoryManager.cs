namespace Ordering.Core.Repositories;

public interface IRepositoryManager
{
    IOrderRepository Order { get; }
    Task SaveAsync();
}