using Microsoft.AspNetCore.Mvc;
using TheCSharpers_QuikTix.Models;

[ApiController]
[Route("api/[controller]")]
public class CartController : ControllerBase
{
    private readonly IPaymentService _paymentService;

    public CheckoutController(IPaymentService paymentService)
    {
        _paymentService = paymentService;
    }
    
    [HttpPost("checkout")]
    public IActionResult Checkout([FromBody] CheckoutRequest checkoutRequest)
    {
        var tickets = _cartService.Tickets.Where(t => checkoutRequest.TicketIds.Contains(t.Id)).ToList();
        var total = tickets.Sum(t => t.Price * t.Quantity);
        var discount = total * 0.10m;  // Example 10% discount
        var tax = total * 0.07m;  // Example 7% tax

        var finalAmount = total - discount + tax;
        return Ok(new { Total = total, Discount = discount, Tax = tax, FinalAmount = finalAmount });
    }

}
