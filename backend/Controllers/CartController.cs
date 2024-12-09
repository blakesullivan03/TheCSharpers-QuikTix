using Microsoft.AspNetCore.Mvc;
using TheCSharpers_QuikTix.Models;
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

        // Define a POST method for adding tickets to the cart
        [HttpPost("add-to-cart")]
        public IActionResult AddTicketToCart([FromBody] AddTicketRequest request)
        {
            if (request == null || request.AdultTickets < 0 || request.ChildTickets < 0)
            {
                return BadRequest("Invalid ticket data.");
            }

            // Define ticket prices (you can retrieve these from a database or another service)
            decimal adultTicketPrice = 12.50m;  // Price for adult tickets
            decimal childTicketPrice = 8.00m;   // Price for child tickets

            // Add adult tickets to the cart
            if (request.AdultTickets > 0)
            {
                var adultCartItem = new Cart
                {
                    MovieId = request.MovieId,
                    TicketType = "Adult",
                    Quantity = request.AdultTickets,
                    Price = adultTicketPrice
                };
                _context.Carts.Add(adultCartItem);
            }

            // Add child tickets to the cart
            if (request.ChildTickets > 0)
            {
                var childCartItem = new Cart
                {
                    MovieId = request.MovieId,
                    TicketType = "Child",
                    Quantity = request.ChildTickets,
                    Price = childTicketPrice
                };
                _context.Carts.Add(childCartItem);
            }

            // Update the total price of the cart
            _context.SaveChanges();

            return Ok(new { message = "Tickets added to cart.", cart = _context.Carts });
        }

        [HttpGet("get-cart")]
        public IActionResult GetCart()
        {
            var cart = _context.Carts.ToList();
            return Ok(cart);
        }

        [HttpDelete("clear-cart")]
        public IActionResult ClearCart()
        {
            _context.Carts.RemoveRange(_context.Carts);
            _context.SaveChanges();
            return Ok(new { message = "Cart cleared." });
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
