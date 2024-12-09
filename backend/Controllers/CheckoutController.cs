using Microsoft.AspNetCore.Mvc;
using TheCSharpers_QuikTix.Models;
using TheCSharpers_QuikTix.Services.Interfaces;
using Microsoft.AspNetCore.Cors;

[EnableCors("AllowAll")]
[ApiController]
[Route("api/[controller]")]
public class CheckoutController : ControllerBase
{
    private readonly IPaymentService _paymentService;

    public CheckoutController(IPaymentService paymentService)
    {
        _paymentService = paymentService;
    }
    
    /*[HttpPost("checkout")]
    public IActionResult Checkout([FromBody] CheckoutRequest checkoutRequest)
    {
        var tickets = _cartService.Tickets.Where(t => checkoutRequest.TicketIds.Contains(t.Id)).ToList();
        var total = tickets.Sum(t => t.Price * t.Quantity);
        var discount = total * 0.10m;
        var tax = total * 0.07m; 

        var finalAmount = total - discount + tax;
        return Ok(new { Total = total, Discount = discount, Tax = tax, FinalAmount = finalAmount });
    }*/

}