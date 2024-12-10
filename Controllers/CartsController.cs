using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieApi.Models;
using System.Text.RegularExpressions;

namespace MovieApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartsController : ControllerBase
    {
        private readonly MovieContext _context;

        public CartsController(MovieContext context)
        {
            _context = context;
        }

        // GET: api/Carts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cart>>> GetCarts()
        {
            return await _context.Carts.ToListAsync();
        }

        // GET: api/Carts/GetCart/5
        [HttpGet("GetCart/{id}")]
        public async Task<ActionResult<Cart>> GetCart(long id)
        {
            var cart = await _context.Carts.FindAsync(id);

            if (cart == null)
            {
                return NotFound();
            }

            return cart;
        }

        // PUT: api/Carts/RemoveTicketFromCart/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("RemoveTicketFromCart/{id}")]
        public async Task<IActionResult> PutCart(long id, Cart cart)
        {
            if (id != cart.CartId)
            {
                return BadRequest();
            }

            _context.Entry(cart).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CartExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // PUT: api/Carts/AddTicketToCart/1/5/3
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("AddTicketToCart/{cartId}/{showtimeId}/{quantity}")]
        public async Task<IActionResult> PutCart(long cartId, Cart cart, long showtimeId, int quantity)
        {
            if (cartId != cart.CartId)
            {
                return BadRequest();
            }

            var showtime = await _context.Showtimes.FindAsync(showtimeId);

            if (showtime == null)
            {
                return NotFound();
            }

            List<long> tickets = showtime.Tickets;
            List<long> selectedTickets = tickets.Take(quantity).ToList();
            cart.Tickets.AddRange(selectedTickets);

            _context.Entry(cart).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CartExists(cartId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Carts
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Cart>> PostCart(Cart cart)
        {
            _context.Carts.Add(cart);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetCart), new { id = cart.CartId }, cart);
        }

        // POST: api/Carts/ProcessPayment/1/1234123412341234/1234/cardholderName/123
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("ProcessPayment/{id}/{cardNumber}/{exp}/{cardholderName}/{cvc}")]
        public async Task<ActionResult<Cart>> PostCart(Cart cart, long id, string cardNumber, string exp, string cardholderName, string cvc)
        {
            Regex r1 = new Regex(@"^\d\d\d\d\d\d\d\d\d\d\d\d\d\d\d\d$");

            if (!(r1.Match(cardNumber).Success))
            {
                Console.WriteLine("Bad card number");
                return BadRequest();
            }

            Regex r2 = new Regex(@"^\d\d\d\d$");

            if (!(r2.Match(exp).Success))
            {
                Console.WriteLine("Bad expiration");
                return BadRequest();
            }

            Regex r3 = new Regex(@"^\d\d\d$");

            if (!(r3.Match(cvc).Success))
            {
                Console.WriteLine("Bad cvc");
                return BadRequest();
            }

            _context.Carts.Add(cart);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetCart), new { id = cart.CartId }, cart);
        }

        // DELETE: api/Carts/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCart(long id)
        {
            var cart = await _context.Carts.FindAsync(id);
            if (cart == null)
            {
                return NotFound();
            }

            _context.Carts.Remove(cart);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CartExists(long id)
        {
            return _context.Carts.Any(e => e.CartId == id);
        }
    }
}
