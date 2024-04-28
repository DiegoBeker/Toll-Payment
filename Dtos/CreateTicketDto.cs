using System.ComponentModel.DataAnnotations;
using Toll_Payment.Models;

namespace Toll_Payment.Dtos;
public class CreateTicketDto
{
    [Required(ErrorMessage = "A plate number is required")]
    [RegularExpression(@"^[0-9A-Z]{7}$", ErrorMessage = "The plate number must contain exactly 7 characters and consist of numbers and uppercase letters.")]
    public required string Plate { get; set; }
    [Required(ErrorMessage = "Payment type is required")]
    [Range(0, 1, ErrorMessage = "Payment type must be either 0 or 1")]
    public required PaymentType Type { get; set; }

    public Ticket ToEntity()
    {
        return new Ticket(Plate, Type);
    }
}