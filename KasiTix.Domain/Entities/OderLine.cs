namespace KasiTix.Domain.Entities;

public class OrderLine
{
    public Guid Id { get; private set; }

    public Guid OrderId { get; private set; }

    public Guid TicketTypeId { get; private set; }

    public int Quantity { get; private set; }

    public decimal UnitPrice { get; private set; }

    private OrderLine(){}

    public OrderLine(Guid ticketTypeId,
        int quantity,
        decimal unitPrice)
    {
        Id = Guid.NewGuid();
        TicketTypeId = ticketTypeId;
        Quantity = quantity;
        UnitPrice = unitPrice;
    }
}
