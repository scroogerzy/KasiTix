using KasiTix.Api.DTOs;
using KasiTix.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace KasiTix.Api.Controllers;

[ApiController]
[Route("api/events")]
public class EventsController : ControllerBase
{
    private readonly EventService _service;

    public EventsController(EventService service)
    {
        _service = service;
    }

    [HttpPost]
    [ProducesResponseType(201)]
    [ProducesResponseType(400)]
    public async Task<IActionResult> Create(
        CreateEventRequest request)
    {
        var id = await _service.CreateEvent(
            request.Name,
            request.Venue,
            request.StartsAt);

        return CreatedAtAction(
            nameof(GetById),
            new { id },
            null);
    }

    [HttpGet("{id:guid}")]
    [ProducesResponseType(200)]
    [ProducesResponseType(404)]
    public async Task<IActionResult> GetById(Guid id)
    {
        var ev = await _service.GetEvent(id);

        return Ok(ev);
    }

    [HttpPost("{id:guid}/ticket-types")]
    [ProducesResponseType(201)]
    [ProducesResponseType(404)]
    [ProducesResponseType(409)]
    [ProducesResponseType(422)]
    public async Task<IActionResult> AddTicketType(
        Guid id,
        CreateTicketTypeRequest request)
    {
        await _service.AddTicketType(
            id,
            request.Name,
            request.Price,
            request.Capacity);

        return StatusCode(201);
    }

    [HttpPost("{id:guid}/publish")]
    [ProducesResponseType(204)]
    [ProducesResponseType(404)]
    [ProducesResponseType(422)]
    public async Task<IActionResult> Publish(Guid id)
    {
        await _service.Publish(id);

        return NoContent();
    }
}
