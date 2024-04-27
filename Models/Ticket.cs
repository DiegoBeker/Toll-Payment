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
    private static readonly int Tariff = 790;

    public Ticket()
    {
        CreatedAt = DateTime.UtcNow;
    }
    
    public Ticket(string plate) : this()
    {
        PlateNumber = plate;
    }

}