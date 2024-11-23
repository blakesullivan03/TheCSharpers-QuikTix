using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using TheCSharpers_QuikTix.Models;

public class QuikTixDbContext : DbContext
{
    public DbSet<Movie> Movies { get; set; } = null!;
    //public DbSet<Ticket> Tickets { get; set; }
    //public DbSet<Cart> Carts { get; set; }

    public QuikTixDbContext(DbContextOptions<QuikTixDbContext> options) : base(options) { }
}
