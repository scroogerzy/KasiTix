using KasiTix.Domain.Entities;

namespace KasiTix.Domain.Repositories;

public interface IOrderRepository
{
    Task<Order?> GetByIdempotencyKeyAsync(string key);

    Task AddAsync(Order order);

    Task SaveChangesAsync();
}
