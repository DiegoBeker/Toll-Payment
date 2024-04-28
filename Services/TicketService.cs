using Toll_Payment.Dtos;
using Toll_Payment.Helpers;
using Toll_Payment.Models;
using Toll_Payment.Repositories;

namespace Toll_Payment.Services;

public class TicketService
{
    private readonly TicketRepository _ticketRepository;
    private readonly int FEE = 790;

    public TicketService(TicketRepository ticketRepository)
    {
        _ticketRepository = ticketRepository;
    }

    public async Task<Ticket> CreateTicket(CreateTicketDto data)
    {
        int ticketsOnCurrentMonth = await _ticketRepository.CountMonthTicketsByPlate(data.Plate);

        Ticket newTicket = data.ToEntity();
        newTicket.Value = FEE;
        newTicket.PaidValue = ValueCalculator.CalculateValueToPay(ticketsOnCurrentMonth, FEE);
        newTicket.PaymentStatus = data.Type == 0 ? PaymentStatus.SUCCESS : PaymentStatus.PROCESSING;
        Ticket createdTicket = await _ticketRepository.CreateTicket(newTicket);

        return createdTicket;
    }

    public async Task<Ticket?> UpdatePaymentStatus(PaymentStatus ticketStatus, long ticketIdParsed)
    {
        Ticket? ticket = await _ticketRepository.UpdatePaymentStatus(ticketStatus, ticketIdParsed);

        return ticket;
    }
}