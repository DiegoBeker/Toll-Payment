using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Toll_Payment.Models;

public class Ticket
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long Id { get; set; }
    public DateTime? CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public string PlateNumber { get; set; }
    public int Value { get; set; }
    public int PaidValue { get; set; }
    public PaymentStatus PaymentStatus { get; set; }
    public PaymentType PaymentType { get; set; }

    public Ticket()
    {

    }

    public Ticket(string plate, PaymentType paymentType) : this()
    {
        PlateNumber = plate;
        PaymentType = paymentType;
    }

}