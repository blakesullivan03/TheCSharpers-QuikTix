using System;
using System.Collections.Generic;
using System.Linq;
using TheCSharpers_QuikTix.Models;
using TheCSharpers_QuikTix.Services;
using TheCSharpers_QuikTix.Pages;
using TheCSharpers_QuikTix.Controllers;


namespace TheCSharpers_QuikTix
{
    public class Program
    {
        static void Main(string[] args)
        {
            Boolean hasExited = false;
            // Create a New Customer
            /*
            var customer = new Customer(
                1,
                "John Doe",
                "john.doe@example.com",
                "123-456-7890"
            );
            */

            // Set up All Services
            var backendService = new StorageService();
            var movieService = new MovieService(backendService);
            var customerService = new CustomerService(backendService);
            var cartService = new CartService();
            var paymentService = new PaymentService();

            // Add a Customer to the Service
            // customerService.AddCustomer(customer);
            List<Customer> customers = customerService.GetAllCustomers();
            Customer customer = customers[0];


            /*
            // Add a Few Sample Movies
            movieService.AddMovie(new Movie(
                1,
                "Inception",
                "Sci-Fi",
                "A mind-bending thriller",
                DateTime.Now.AddHours(2),
                100
            ));
            movieService.AddMovie(new Movie(
                2,
                "The Dark Knight",
                "Action",
                "The best Batman movie",
                DateTime.Now.AddHours(3),
                50
            ));
            movieService.AddMovie(new Movie(
                3,
                "The Matrix",
                "Sci-Fi",
                "A classic",
                DateTime.Now.AddHours(4),
                75
            ));
            */

            var welcomePage = new WelcomePage(movieService);

            var movieListingPage = new MovieListingPage(movieService, cartService);

            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();

            while (!hasExited)
            {
                // Display All Movies
                welcomePage.DisplayMovies();

                // Ask the User What Movie They Want to Watch
                Console.WriteLine("Enter the Name of the Movie you Want to Watch:");
                string movieName = Console.ReadLine() ?? string.Empty;

                // Validate Input
                var movie = movieService.GetMovieByName(movieName);
                while (movie == null)
                {
                    Console.WriteLine("Invalid Input. Please enter a Valid Movie Name:");
                    movieName = Console.ReadLine() ?? string.Empty;
                    movie = movieService.GetMovieByName(movieName);
                }


                // Display Movie Details
                Console.WriteLine();
                movieListingPage.DisplayMovieDetails(movieName);

                // Display The Cart
                var cartPage = new CartPage(cartService);
                cartPage.DisplayCart();

                // Process Checkout
                var checkoutPage = new CheckoutPage(cartService, paymentService, customer);
                checkoutPage.DisplayCheckout();

                // Display purchase history
                Console.WriteLine("\nPurchase History:");
                foreach (var ticket in customer.PurchaseHistory)
                {
                    Console.WriteLine($"Movie: {ticket.Movie.Name}, Quantity: {ticket.Quantity}, Price: {ticket.Price}");
                }

                hasExited = checkoutPage.ExitProgram();
            }
        }
    }
}
