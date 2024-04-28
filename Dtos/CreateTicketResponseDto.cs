using Toll_Payment.Models;

namespace Toll_Payment.Dtos;
public class CreateTicketResponseDto
{
    public string Date { get; set; }
    public string PlateNumber { get; set; }
    public int Value { get; set; }
    public int PaidValue { get; set; }
    public string PaymentStatus { get; set; }
    public string PaymentType { get; set; }

    public CreateTicketResponseDto(Ticket ticket)
    {
        Date = DateTime.UtcNow.ToString("dd/MM/yyyy HH:mm:ss");
        PlateNumber = ticket.PlateNumber;
        Value = ticket.Value;
        PaidValue = ticket.PaidValue;
        PaymentStatus = ticket.PaymentStatus.ToString();
        PaymentType = ticket.PaymentType.ToString();
    }
}