using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using TheCSharpers_QuikTix.Models;

public class QuikTixDbContext : DbContext
{
    public DbSet<Movie> Movies { get; set; } = null!;
    public QuikTixDbContext(DbContextOptions<QuikTixDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Movie>(entity =>
        {
            entity.HasKey(m => m.Id);
            entity.Property(m => m.Title).IsRequired();
        });
    }
}
