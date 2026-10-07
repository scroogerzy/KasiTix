using KasiTix.Domain.Entities;

namespace KasiTix.Domain.Repositories;

public interface IEventRepository
{
    Task AddAsync(Event ev);

    Task<Event?> GetByIdAsync(Guid id);

    Task SaveChangesAsync();
}