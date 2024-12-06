using Microsoft.EntityFrameworkCore;
using TheCSharpers_QuikTix.Services.Interfaces;
using TheCSharpers_QuikTix.Services.Implementation;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add DbContext for Entity Framework Core
builder.Services.AddDbContext<QuikTixDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

// Add custom services (e.g., Movie, Cart, Review services)
builder.Services.AddScoped<IMovieService, MovieService>();
//builder.Services.AddScoped<ICartService, CartService>();
//builder.Services.AddScoped<IReviewService, ReviewService>();


var app = builder.Build();

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
