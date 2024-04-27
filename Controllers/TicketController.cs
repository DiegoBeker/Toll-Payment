using Microsoft.AspNetCore.Mvc;
using Toll_Payment.Dtos;
using Toll_Payment.Models;
using Toll_Payment.Services;

namespace Toll_Payment.Controllers;

[ApiController]
[Route("tickets")]
public class TicketController : ControllerBase
{
    private readonly TicketService _ticketservice;
    public TicketController(TicketService ticketservice)
    {
        _ticketservice = ticketservice;
    }

    [HttpPost]
    public async Task<IActionResult> CreateTicket([FromBody] CreateTicketDto dto)
    {
        Ticket ticket = await _ticketservice.CreateTicket(dto);
        
        CreateTicketResponseDto response = new(ticket);

        return CreatedAtAction(null, null, response);
    }

}