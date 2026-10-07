using KasiTix.Domain.Entities;
using KasiTix.Domain.Repositories;
using KasiTix.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace KasiTix.Infrastructure.Repositories;

public class OrderRepository : IOrderRepository
{
    private readonly KasiTixDbContext _db;

    public OrderRepository(KasiTixDbContext db)
    {
        _db = db;
    }

    public async Task<Order?> GetByIdempotencyKeyAsync(string key)
    {
        return await _db.Orders
            .Include(x => x.Lines)
            .FirstOrDefaultAsync(x => x.IdempotencyKey == key);
    }

    public async Task AddAsync(Order order)
    {
        await _db.Orders.AddAsync(order);
    }

    public async Task SaveChangesAsync()
    {
        await _db.SaveChangesAsync();
    }
}