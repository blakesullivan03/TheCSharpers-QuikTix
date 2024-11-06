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
            var customer = new Customer(
                1,
                "John Doe",
                "john.doe@example.com",
                "123-456-7890"
            );

            // Set up All Services
            var movieService = new MovieService();
            var customerService = new CustomerService();
            var cartService = new CartService();
            var paymentService = new PaymentService();

            // Add a Customer to the Service
            customerService.AddCustomer(customer);

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
            var welcomePage = new WelcomePage(movieService);

            var movieListingPage = new MovieListingPage(movieService, cartService);

            while (!hasExited)
            {
                // Display All Movies
                welcomePage.DisplayMovies();
                // Ask the User What Movie They Want to Watch
                Console.WriteLine("Enter the ID of the movie you want to watch:");
                int movieId;
                while (!int.TryParse(Console.ReadLine(), out movieId))
                {
                    Console.WriteLine("Invalid Input. Please enter a Valid Movie ID:");
                }
                movieListingPage.DisplayMovieDetails(movieId);

                // Display The Cart
                var cartPage = new CartPage(cartService);
                cartPage.DisplayCart();

                // Process Checkout
                var checkoutPage = new CheckoutPage(cartService, paymentService, customer);
                var paymentInfo = new PaymentInfo
                {
                    CardNumber = "1234-5678-9876-5432",
                    CardHolderName = "John Doe",
                    ExpiryDate = DateTime.Now.AddYears(2).ToString("MM/yyyy"),
                    CVV = "123"
                };
                checkoutPage.DisplayCheckout();

                // Display purchase history
                Console.WriteLine("Purchase History:");
                foreach (var ticket in customer.PurchaseHistory)
                {
                    Console.WriteLine($"Movie: {ticket.Movie.Name}, Quantity: {ticket.Quantity}, Price: {ticket.Price}");
                }

                hasExited = checkoutPage.ExitProgram();
            }
        }
    }
}
