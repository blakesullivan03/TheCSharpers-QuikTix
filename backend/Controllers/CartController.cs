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
                    Price = adultTicketPrice * request.AdultTickets
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
                    Price = childTicketPrice * request.ChildTickets
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

        [HttpDelete("remove/{cartId}")]
        public IActionResult RemoveFromCart(int cartId)
        {
            var cartItem = _context.Carts.Find(cartId);
            if (cartItem == null)
            {
                return NotFound();
            }

            _context.Carts.Remove(cartItem);
            _context.SaveChanges();
            return Ok(new { message = "Item removed from cart." });
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
/*using Microsoft.AspNetCore.Mvc;
using TheCSharpers_QuikTix.Models;
using TheCSharpers_QuikTix.Services;

[ApiController]
[Route("api/[controller]")]
public class CartController : ControllerBase
{
    private readonly CartService _cartService;
    private readonly TicketService _ticketService;

    public CartController(CartService cartService, TicketService ticketService)
    {
        _cartService = cartService;
        _ticketService = ticketService;
    }

    // Add ticket to a cart
    [HttpPost("{cartId}/showtime/{showtimeId}/ticket/{ticketType}/price/{price}")]
    public IActionResult AddTicketToCart(int cartId, int showtimeId, string ticketType, decimal price)
    {
        var ticket = _ticketService.CreateTicket(showtimeId, ticketType, price, cartId);
        _cartService.AddTicketToCart(cartId, ticket);
        return Ok(ticket);
    }
}*/
