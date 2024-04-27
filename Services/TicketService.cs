using Toll_Payment.Dtos;
using Toll_Payment.Models;
using Toll_Payment.Repositories;

namespace Toll_Payment.Services;

public class TicketService
{
    private readonly TicketRepository _ticketRepository;

    public TicketService(TicketRepository ticketRepository)
    {
        _ticketRepository = ticketRepository;
    }

    public async Task<Ticket> CreateTicket(CreateTicketDto data)
    {
        Ticket newTicket = data.ToEntity();
        newTicket.PaidValue = Ticket.TARIFF;
        Ticket createdTicket = await _ticketRepository.CreateTicket(newTicket);

        return createdTicket;
    }

}