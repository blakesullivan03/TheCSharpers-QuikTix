using Microsoft.AspNetCore.Mvc;
using TheCSharpers_QuikTix.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace QuikTix.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly QuikTixDbContext _context;

        public CartController(QuikTixDbContext context)
        {
            _context = context;
        }

        // POST Method to Create Cart
        [HttpPost("create-cart")]
        public IActionResult CreateCart([FromBody] Cart request)
        {
            if (request == null || string.IsNullOrEmpty(request.CartId.ToString()))
            {
                return BadRequest("Invalid cart creation request.");
            }

            // Create a New Cart
            var cart = new Cart
            {
                CartId = request.CartId, // Assuming Cart is associated with a User
                Tickets = new List<Ticket>() // Initialize an empty ticket list
            };

            _context.Carts.Add(cart);
            _context.SaveChanges();

            return Ok(new { message = "Cart created successfully.", cart });
        }


        /// Define a POST method for adding tickets to the cart
        [HttpPost("add-to-cart/{cartId}")]
        public IActionResult AddTicketToCart(int cartId, [FromBody] AddTicketRequest request)
        {
            if (request == null || request.AdultTickets < 0 || request.ChildTickets < 0)
            {
                return BadRequest("Invalid ticket data.");
            }

            // Retrieve the Cart
            var cart = _context.Carts.FirstOrDefault(c => c.CartId == cartId);
            if (cart == null)
            {
                return NotFound("Cart not found.");
            }

            // Retrieve the Showtime
            var showtime = _context.Showtimes.FirstOrDefault(s => s.Id == request.ShowtimeId);
            if (showtime == null)
            {
                return NotFound("Showtime not found.");
            }

            // Check Ticket Availability

            if (request.AdultTickets > showtime.AdultTicketCount || request.ChildTickets > showtime.ChildTicketCount)
            {
                return BadRequest("Insufficient tickets available.");
            }

            // Define ticket prices (you can retrieve these from a database or another service)
            decimal adultTicketPrice = 12.50m;  // Price for adult tickets
            decimal childTicketPrice = 8.00m;   // Price for child tickets

            // Add adult tickets to the cart
            if (request.AdultTickets > 0)
            {
                var adultCartItem = new Ticket
                {
                    MovieId = request.MovieId,
                    TicketType = "Adult",
                    Quantity = request.AdultTickets,
                    Price = adultTicketPrice
                };
                cart.Tickets.Add(adultCartItem);
                showtime.AdultTicketCount -= request.AdultTickets;
            }

            // Add child tickets to the cart
            if (request.ChildTickets > 0)
            {
                var childCartItem = new Ticket
                {
                    MovieId = request.MovieId,
                    TicketType = "Child",
                    Quantity = request.ChildTickets,
                    Price = childTicketPrice
                };
                cart.Tickets.Add(childCartItem);
                showtime.ChildTicketCount -= request.ChildTickets;
            }

            _context.Carts.Update(cart);
            _context.Showtimes.Update(showtime);
            _context.SaveChanges();

            return Ok(new { message = "Tickets added to cart.", cart });
        }



        // Get Cart By ID
        [HttpGet("get-cart/{cartId}")]
        public IActionResult GetCartById(int cartId)
        {
            var cart = _context.Carts.Include(c => c.Tickets).FirstOrDefault(c => c.CartId == cartId);
            if (cart == null)
            {
                return NotFound();
            }
            return Ok(cart);
        }

        // Get All Carts
        [HttpGet("get-all-carts")]
        public IActionResult GetAllCarts()
        {
            var carts = _context.Carts;
            return Ok(carts);
        }

        // Clear Cart
        [HttpDelete("clear-cart")]
        public IActionResult ClearCart()
        {
            _context.Carts.RemoveRange(_context.Carts);
            _context.SaveChanges();
            return Ok(new { message = "Cart cleared." });
        }

        [HttpDelete("remove/{cartId}/{ticketId}")]
        public IActionResult RemoveSingleTicket(int cartId, int ticketId)
        {
            // Find the cart item by cartId
            var cartItem = _context.Carts
                .Include(c => c.Tickets) // Assuming 'Tickets' is a navigation property in the 'Cart' model
                .FirstOrDefault(c => c.CartId == cartId);

            if (cartItem == null)
            {
                return NotFound(new { message = $"Cart with ID {cartId} not found." });
            }

            // Find the specific ticket within the cart
            var ticket = cartItem.Tickets.FirstOrDefault(t => t.Id == ticketId);
            if (ticket == null)
            {
                return NotFound(new { message = $"Ticket with ID {ticketId} not found in Cart {cartId}." });
            }

            // Remove the ticket from the cart
            cartItem.Tickets.Remove(ticket);
            _context.SaveChanges();

            return Ok(new { message = $"Ticket with ID {ticketId} removed from Cart {cartId}." });
        }

            }
    

    // Define a class to represent the request body for adding tickets
    public class AddTicketRequest
    {
        public int MovieId { get; set; }
        public int ShowtimeId { get; set; }
        public int AdultTickets { get; set; }
        public int ChildTickets { get; set; }
    }
}
