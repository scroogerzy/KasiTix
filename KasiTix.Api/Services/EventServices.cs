using KasiTix.Domain.Entities;
using KasiTix.Domain.Exceptions;
using KasiTix.Domain.Repositories;

namespace KasiTix.Api.Services;

public class EventService
{
    private readonly IEventRepository _eventRepository;
    private readonly IOrderRepository _orderRepository;

    public EventService(
        IEventRepository eventRepository,
        IOrderRepository orderRepository)
    {
        _eventRepository = eventRepository;
        _orderRepository = orderRepository;
    }

    public async Task<Guid> CreateEvent(
        string name,
        string venue,
        DateTime startsAt)
    {
        var ev = new Event(
            name,
            venue,
            startsAt);

        await _eventRepository.AddAsync(ev);

        await _eventRepository.SaveChangesAsync();

        return ev.Id;
    }

    public async Task<Event> GetEvent(Guid id)
    {
        var ev = await _eventRepository.GetByIdAsync(id);

        if (ev is null)
            throw new NotFoundException(
                "Event not found");

        return ev;
    }

    public async Task AddTicketType(
        Guid eventId,
        string name,
        decimal price,
        int capacity)
    {
        var ev = await GetEvent(eventId);

        if (ev.TicketTypes.Any(x => x.Name == name))
            throw new ConflictException(
                "Ticket type already exists");

        var ticket = new TicketType(
            eventId,
            name,
            price,
            capacity);

        ev.AddTicketType(ticket);

        await _eventRepository.SaveChangesAsync();
    }

    public async Task Publish(Guid eventId)
    {
        var ev = await GetEvent(eventId);

        ev.Publish();

        await _eventRepository.SaveChangesAsync();
    }
}