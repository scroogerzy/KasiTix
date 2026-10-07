using KasiTix.Domain.Enums;

namespace KasiTix.Domain.Entities;

public class Order
{
    public Guid Id { get; private set; }

    public Guid EventId { get; private set; }

    public string BuyerEmail { get; private set; }

    public string IdempotencyKey { get; private set; }

    public OrderStatus Status { get; private set; }

    public DateTime CreatedAt { get; private set; }

    public List<OrderLine> Lines { get; private set; } = [];

    private Order(){}

    public Order(Guid eventId,string email,string key)
    {
        Id = Guid.NewGuid();
        EventId = eventId;
        BuyerEmail = email;
        IdempotencyKey = key;
        Status = OrderStatus.Confirmed;
        CreatedAt = DateTime.UtcNow;
    }
}