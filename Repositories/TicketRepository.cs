using Toll_Payment.Data;
using Toll_Payment.Models;

namespace Toll_Payment.Repositories;

public class TicketRepository
{
    private readonly AppDBContext _context;
    public TicketRepository(AppDBContext context)
    {
        _context = context;
    }

    public async Task<Ticket> CreateTicket(Ticket Ticket)
    {
        _context.Ticket.Add(Ticket);
        await _context.SaveChangesAsync();
        return Ticket;
    }

}