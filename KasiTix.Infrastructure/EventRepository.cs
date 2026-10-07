using KasiTix.Domain.Entities;
using KasiTix.Domain.Repositories;
using KasiTix.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace KasiTix.Infrastructure.Repositories;

public class EventRepository : IEventRepository
{
    private readonly KasiTixDbContext _db;

    public EventRepository(KasiTixDbContext db)
    {
        _db = db;
    }

    public async Task AddAsync(Event ev)
    {
        await _db.Events.AddAsync(ev);
    }

    public async Task<Event?> GetByIdAsync(Guid id)
    {
        return await _db.Events
            .Include(x => x.TicketTypes)
            .FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task SaveChangesAsync()
    {
        await _db.SaveChangesAsync();
    }
}