namespace KasiTix.Api.DTOs;

public record CreateOrderRequest(
    string BuyerEmail,
    List<OrderLineRequest> Lines
);

public record OrderLineRequest(
    Guid TicketTypeId,
    int Quantity
);