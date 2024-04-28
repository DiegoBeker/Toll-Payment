using Microsoft.EntityFrameworkCore;
using Toll_Payment.Data;
using Toll_Payment.Exceptions;
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

    public async Task<int> CountMonthTicketsByPlate(string plateNumber)
    {
        DateTime todayUtc = DateTime.UtcNow;
        DateTime startOfMonth = new DateTime(todayUtc.Year, todayUtc.Month, 1, 0, 0, 0, DateTimeKind.Utc);
        DateTime endOfMonth = startOfMonth.AddMonths(1).AddSeconds(-1);

        int count = await _context.Ticket
            .Where(t => t.PlateNumber == plateNumber && t.CreatedAt >= startOfMonth && t.CreatedAt <= endOfMonth)
            .CountAsync<Ticket>();

        return count;
    }

    public async Task<Ticket?> UpdatePaymentStatus(PaymentStatus status, long ticketId)
    {

        var ticket = await _context.Ticket
            .Where(e => e.Id.Equals(ticketId))
            .FirstOrDefaultAsync();

        if (ticket != null)
        {
            ticket.PaymentStatus = status;
            await _context.SaveChangesAsync();
        }
        else
        {
            throw new NotFoundException("Ticket not found.");
        }

        return ticket;
    }
}