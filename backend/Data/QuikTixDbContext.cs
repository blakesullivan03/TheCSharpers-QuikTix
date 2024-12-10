using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Sqlite;
using TheCSharpers_QuikTix.Models;

public class QuikTixDbContext : DbContext
{
    public DbSet<Movie> Movies { get; set; } = null!;
    public DbSet<Showtime> Showtimes { get; set; } = null!;
    public DbSet<Cart> Carts { get; set; } = null!;

    public DbSet<Review> Reviews { get; set; } = null!;

    public DbSet<Ticket> Tickets { get; set; } = null!;
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
            entity.Property(m => m.Rating)
                .IsRequired(false);  // Rating is nullable (doesn't need additional configuration if nullable)
        });

        // Configure the Cart entity
        modelBuilder.Entity<Cart>(entity =>
        {
            entity.HasKey(c => c.CartId);  // Setting CartId as the primary key
            entity.Property(c => c.Price)
                .HasColumnType("decimal(18,2)");  // Define price precision and scale
        });

        modelBuilder.Entity<Ticket>(entity =>
                {
                    entity.HasKey(t => t.Id);  // Setting Id as the primary key
                    entity.Property(t => t.ShowtimeId)
                        .IsRequired();
                    entity.Property(t => t.TicketType)
                        .IsRequired();
                    entity.Property(t => t.Price)
                        .IsRequired();
                    entity.Property(t => t.PurchaseTime)
                        .IsRequired();
                    entity.Property(t => t.CartId)
                    .IsRequired();
                    entity.Property(t => t.MovieId)
                    .IsRequired();
                    entity.Property(t => t.IsAvailable)
                        .IsRequired();
                });

        modelBuilder.Entity<Showtime>(entity =>
        {
            entity.HasKey(s => s.Id);
            entity.Property(s => s.MovieId).IsRequired();
            entity.Property(s => s.StartTime).IsRequired();
            entity.Property(s => s.AdultTicketCount).IsRequired();
            entity.Property(s => s.ChildTicketCount).IsRequired();
        });

        // Configure the Review entity
        modelBuilder.Entity<Review>(entity =>
        {
            entity.HasKey(r => r.Id);  // Setting Id as the primary key
            entity.Property(r => r.ReviewerName)
                .IsRequired(false);
            entity.Property(r => r.Comment)
                .IsRequired(false);
            entity.Property(r => r.Rating)
                .IsRequired();
            entity.Property(r => r.MovieId)
                .IsRequired();
        });

    }
}
