using Microsoft.AspNetCore.Mvc;
using TheCSharpers_QuikTix.Models;
using TheCSharpers_QuikTix.Services.Interfaces;
using TheCSharpers_QuikTix.Services;
using Microsoft.AspNetCore.Cors;

[EnableCors("AllowAll")]
[ApiController]
[Route("api/[controller]")]
public class CheckoutController : ControllerBase
{
    private readonly IPaymentService _paymentService;
    private readonly ICartService _cartService;
    private readonly ICustomerService _customerService;

    public CheckoutController(IPaymentService paymentService, ICartService cartService, ICustomerService customerService)
    {
        _paymentService = paymentService;
        _cartService = cartService;
        _customerService = customerService;
    }

    //POST: api/process-payment
    [HttpPost("process-payment")]
    public IActionResult ProcessPayment([FromBody] PaymentInfo paymentRequest)
    {

        // Get Cart
        var cart = _cartService.GetCartById(paymentRequest.CartId);

        // Get Customer
        var customer = _customerService.GetCustomerById(paymentRequest.CustomerId);

        // Create PaymentInfo Object
        var paymentInfo = new PaymentInfo
        {
            CardNumber = paymentRequest.CardNumber,
            ExpiryDate = paymentRequest.ExpiryDate,
            CVV = paymentRequest.CVV,   
            CardHolderName = paymentRequest.CardHolderName
        };

        //Process Payment
        var isPaymentSuccesful = _paymentService.ProcessPayment(paymentInfo, cart, customer);
        
        if(isPaymentSuccesful)
        {
            return Ok("Payment Successful");
        }
        return BadRequest("Payment Failed");
    }
    
}