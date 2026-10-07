namespace KasiTix.Api.DTOs;

public record CreateTicketTypeRequest(
    string Name,
    decimal Price,
    int Capacity
);
