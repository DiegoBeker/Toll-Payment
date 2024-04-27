using Microsoft.EntityFrameworkCore;
using Toll_Payment.Models;

namespace Toll_Payment.Data;

public class AppDBContext(DbContextOptions<AppDBContext> options) : DbContext(options)
{
	public DbSet<Ticket> Ticket { get; set; }
}