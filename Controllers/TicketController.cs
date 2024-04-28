using Microsoft.AspNetCore.Mvc;
using Toll_Payment.Dtos;
using Toll_Payment.Models;
using Toll_Payment.Services;

namespace Toll_Payment.Controllers;

[ApiController]
[Route("tickets")]
public class TicketController : ControllerBase
{
    private readonly TicketService _ticketService;
    public TicketController(TicketService ticketService)
    {
        _ticketService = ticketService;
    }

    [HttpPost]
    public async Task<IActionResult> CreateTicket([FromBody] CreateTicketDto dto)
    {
        Ticket ticket = await _ticketService.CreateTicket(dto);
        
        CreateTicketResponseDto response = new(ticket);

        return CreatedAtAction(null, null, response);
    }

    [HttpPatch("{status}/{ticketId}")]
    public async Task<IActionResult> UpdatePaymentStatus(string status, string ticketId)
    {
        if (!Enum.TryParse(status, true, out PaymentStatus ticketStatus) || !long.TryParse(ticketId, out long ticketIdParsed))
        {
            return BadRequest("Invalid Status");
        }

        await _ticketService.UpdatePaymentStatus(ticketStatus, ticketIdParsed);

        return NoContent();
    }

}