using Microsoft.EntityFrameworkCore;  // For EF Core
using Microsoft.EntityFrameworkCore.Sqlite;  // For SQLite support
using TheCSharpers_QuikTix.Models;  // For Movie model

namespace TheCSharpers_QuikTix.Data {
public class QuikTixDbContext : DbContext
{
    // Define the DbSet for your entities
    public DbSet<Movie> Movies { get; set; } = null!;
    public DbSet<Cart> Carts { get; set; } = null!;

    // Constructor for injecting options into the DbContext
    public QuikTixDbContext(DbContextOptions<QuikTixDbContext> options) : base(options) { }

    // Configure model-specific settings like keys, indexes, relationships, etc.
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Configure the Movie entity
        modelBuilder.Entity<Movie>(entity =>
        {
            entity.HasKey(m => m.Id);  // Setting Id as the primary key
            entity.Property(m => m.Title)
                .IsRequired();  // Title is required
            entity.Property(m => m.Genre)
                .IsRequired();  // Genre is required
            entity.Property(m => m.Description)
                .IsRequired();  // Description is required
            entity.Property(m => m.ImagePath)
                .IsRequired();  // ImagePath is required

            entity.Property(m => m.Rating)
                .IsRequired(false);  // Rating is nullable (doesn't need additional configuration if nullable)

            entity.Property(m => m.ReleaseDate)
                .HasColumnType("TEXT");  // Ensures correct date format for SQLite

            entity.Property(m => m.TicketCount)
                .IsRequired();  // TicketCount is required
        });
    }
}
}