namespace KasiTix.Api.DTOs;

public record CreateEventRequest(
    string Name,
    string Venue,
    DateTime StartsAt
);
