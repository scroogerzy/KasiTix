using KasiTix.Domain.Enums;
using KasiTix.Domain.Exceptions;

namespace KasiTix.Domain.Entities;

public class Event
{
    public Guid Id { get; private set; }

    public string Name { get; private set; }

    public string Venue { get; private set; }

    public DateTime StartsAt { get; private set; }

    public EventStatus Status { get; private set; }

    public List<TicketType> TicketTypes { get; private set; } = [];

    private Event(){}

    public Event(string name,string venue,DateTime startsAt)
    {
        Id = Guid.NewGuid();
        Name = name;
        Venue = venue;
        StartsAt = startsAt;
        Status = EventStatus.Draft;
    }

    public void AddTicketType(TicketType ticket)
    {
        if(Status != EventStatus.Draft)
            throw new UnprocessableEntityException("Event not draft");

        TicketTypes.Add(ticket);
    }

    public void Publish()
    {
        if(Status == EventStatus.Cancelled)
            throw new UnprocessableEntityException("Cancelled");

        if(!TicketTypes.Any())
            throw new UnprocessableEntityException("No ticket types");

        Status = EventStatus.Published;
    }

    public void Cancel()
    {
        Status = EventStatus.Cancelled;
    }
}