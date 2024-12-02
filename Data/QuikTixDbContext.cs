using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using TheCSharpers_QuikTix.Models;

public class QuikTixDbContext : DbContext
{
    public DbSet<Movie> Movies { get; set; } = null!;
    public DbSet<Cart> Cart { get; set; } = null!;
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
        });

        modelBuilder.Entity<Ticket>(entity =>
        {
            entity.HasKey(t => t.Id);
        });

    }
}
