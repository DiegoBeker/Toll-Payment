using System.ComponentModel.DataAnnotations;
using Toll_Payment.Models;

namespace Toll_Payment.Dtos;
public class CreateTicketResponseDto
{
    public string PlateNumber { get; set; }
    public int PaidValue { get; set; }
    public string PaymentStatus { get; set; }

    public CreateTicketResponseDto(Ticket ticket)
    {
        PlateNumber = ticket.PlateNumber;
        PaidValue = ticket.PaidValue;
        PaymentStatus = PaymentStatusParser.ParseStatus(ticket.PaymentStatus);
    }
}