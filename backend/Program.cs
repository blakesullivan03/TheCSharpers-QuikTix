using Microsoft.EntityFrameworkCore;
using TheCSharpers_QuikTix.Services;
using TheCSharpers_QuikTix.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add DbContext for Entity Framework Core
builder.Services.AddDbContext<QuikTixDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));


// Add custom services (e.g., Movie, Cart, Review services)
builder.Services.AddScoped<IMovieService, MovieService>();
builder.Logging.AddConsole();
builder.Logging.AddDebug();

//builder.Services.AddScoped<ICartService, CartService>();
//builder.Services.AddScoped<IReviewService, ReviewService>();

var app = builder.Build();

// Ensure the database is created and seed the data
using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<QuikTixDbContext>();
    // Call the MovieSeeder method to seed the movies into the database
    MovieSeeder.SeedMovies(context);
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();

app.MapControllers(); // Map controller endpoints (e.g., MoviesController, CartController, etc.)

app.Run();
