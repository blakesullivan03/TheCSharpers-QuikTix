using Microsoft.EntityFrameworkCore;
using TheCSharpers_QuikTix.Services;
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
builder.Services.AddScoped<ICartService, CartService>();
builder.Services.AddScoped<ITicketService, TicketService>();
builder.Services.AddScoped<IShowtimeService, ShowtimeService>();
//builder.Services.AddScoped<ITicketService, TicketService>();
//builder.Services.AddScoped<IReviewService, ReviewService>();

// Use CORDS to allow the Frontend to Make Requests
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", builder =>
        builder.AllowAnyOrigin() // You can specify the allowed origins if you want to restrict this to a specific domain.
               .AllowAnyMethod()
               .AllowAnyHeader());
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    Console.WriteLine("Swagger is Availabe at:");
    Console.WriteLine("https://localhost:7267/swagger/index.html");
}

app.UseCors("AllowAll");

app.UseHttpsRedirection();
app.UseAuthorization();

app.MapControllers(); // Map controller endpoints (e.g., MoviesController, CartController, etc.)

app.Run();
