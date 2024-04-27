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
    public int PaidValue { get; set; }
    public PaymentStatus PaymentStatus { get; set; }
    public static readonly int TARIFF = 790;

    public Ticket()
    {
        PaymentStatus = PaymentStatus.PROCESSING;
    }

    public Ticket(string plate) : this()
    {
        PlateNumber = plate;
    }

}