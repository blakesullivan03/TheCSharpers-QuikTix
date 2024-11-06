using System;
using System.Collections.Generic;
using System.Linq;
using TheCSharpers_QuikTix.Models;
using TheCSharpers_QuikTix.Services;
using TheCSharpers_QuikTix.Pages;


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

            while (!hasExited)
            {
                // Display All Movies
                welcomePage.DisplayMovies();
                // Ask the User What Movie They Want to Watch
                Console.WriteLine("Enter the Name of the Movie you Want to Watch:");
                string? movieName = Console.ReadLine();
                while (string.IsNullOrEmpty(movieName))
                {
                    Console.WriteLine("Invalid Input. Please enter a Valid Movie Name:");
                    movieName = Console.ReadLine();
                }
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
