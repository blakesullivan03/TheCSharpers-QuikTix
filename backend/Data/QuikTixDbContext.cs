using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Sqlite;
using TheCSharpers_QuikTix.Models;

public class QuikTixDbContext : DbContext
{
    public DbSet<Movie> Movies { get; set; } = null!;
    public DbSet<Showtime> Showtimes { get; set; } = null!;
    public DbSet<Cart> Carts { get; set; } = null!;
    
    public DbSet<Ticket> Tickets {get; set; } = null!;
    public QuikTixDbContext(DbContextOptions<QuikTixDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Movie>(entity =>
        {
            entity.HasKey(m => m.Id);
            entity.Property(m => m.Title).IsRequired();
        });

        modelBuilder.Entity<Cart>(entity =>
        {
            entity.HasKey(c => c.CartId);
            entity.Property(c => c.Price).HasColumnType("decimal(18,2)");
        });

        modelBuilder.Entity<Ticket>(entity =>
        {
            entity.HasKey(t => t.Id);
            entity.Property(t => t.Price).HasColumnType("decimal(18,2)");
        });

        modelBuilder.Entity<Showtime>(entity =>
        {
            entity.HasKey(s => s.Id);
            entity.Property(s => s.MovieId).IsRequired();
            entity.Property(s => s.StartTime).IsRequired();
            entity.Property(s => s.AdultTicketCount).IsRequired();
            entity.Property(s => s.ChildTicketCount).IsRequired();
        });

    }
}
