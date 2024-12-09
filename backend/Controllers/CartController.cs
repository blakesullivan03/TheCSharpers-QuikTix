using Microsoft.AspNetCore.Mvc;
using TheCSharpers_QuikTix.Models;
using Microsoft.AspNetCore.Cors;
using System.Linq;

[EnableCors("AllowAll")]
[ApiController]
[Route("api/[controller]")]
public class CartController : ControllerBase
{
    private readonly ICartService _cartService;

    public CartController(ICartService cartService)
    {
        _cartService = cartService;
    }
    
    [HttpGet("getcart")]
    public IActionResult GetCart()
    {
        try
        {
            var cart = _cartService.GetCartItems();
            
            if (cart == null || !cart.Any())
            {
                return NotFound("Cart is empty.");
            }
            
            return Ok(cart);
        }
        catch (Exception ex)
        {
            return BadRequest($"Error fetching cart: {ex.Message}");
        }
    }

    [HttpPost("add")]
    public IActionResult AddToCart([FromBody] Cart item)
    {
        if (item == null || item.Quantity <= 0)
        {
            return BadRequest("Invalid item data.");
        }

        try
        {
            _cartService.AddToCart(item);
            return Ok("Item added to cart.");
        }
        catch (ArgumentException ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpDelete("remove")]
    public IActionResult RemoveFromCart([FromQuery] int movieId, [FromQuery] string ticketType)
    {
        if (movieId <= 0 || string.IsNullOrEmpty(ticketType))
        {
            return BadRequest("Invalid movieId or ticketType.");
        }

        try
        {
            _cartService.RemoveFromCart(movieId, ticketType);
            return Ok("Item removed from cart.");
        }
        catch (KeyNotFoundException)
        {
            return NotFound("Cart item not found.");
        }
    }

    [HttpPost("clear")]
    public IActionResult ClearCart()
    {
        _cartService.ClearCart();
        return Ok("Cart cleared.");
    }

    [HttpGet("total")]
    public IActionResult CalculateTotal()
    {
        var total = _cartService.CalculateTotal();
        return Ok(new { TotalAmount = total });
    }
}
