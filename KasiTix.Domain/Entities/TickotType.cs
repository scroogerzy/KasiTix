using KasiTix.Domain.Exceptions;

namespace KasiTix.Domain.Entities;

public class TicketType
{
    public Guid Id { get; private set; }

    public Guid EventId { get; private set; }

    public string Name { get; private set; }

    public decimal Price { get; private set; }

    public int Capacity { get; private set; }

    public int Sold { get; private set; }

    public uint Version { get; set; }

    private TicketType(){}

    public TicketType(Guid eventId,string name,
        decimal price,int capacity)
    {
        Id = Guid.NewGuid();
        EventId = eventId;
        Name = name;
        Price = price;
        Capacity = capacity;
    }

    public int Remaining => Capacity - Sold;

    public void Reserve(int qty)
    {
        if(Remaining < qty)
            throw new ConflictException("Not enough tickets");

        Sold += qty;
    }

    public void Release(int qty)
    {
        Sold -= qty;
    }
}
