using System;
using TheCSharpers_QuikTix.Services;
using TheCSharpers_QuikTix.Models;

public class CheckoutPage
{
    private readonly CartService _cartService;
    private readonly PaymentService _paymentService;
    private readonly Customer _customer;

    public CheckoutPage(CartService cartService, PaymentService paymentService, Customer customer)
    {
        _cartService = cartService;
        _paymentService = paymentService;
        _customer = customer;
    }

    // Process the checkout and payment
    public void DisplayCheckout()
    {
        var cart = _cartService.GetCart();
        if (cart.Tickets.Count == 0)
        {
            Console.WriteLine("Your cart is empty.");
            return;
        }

        Console.WriteLine("Checkout:");
        //Console.WriteLine($"Total Cost: {cart.TotalCost}");

        Console.WriteLine("Enter Payment Details:");
        Console.Write("Card Number: ");
        string cardNumber = Console.ReadLine() ?? string.Empty;
        Console.Write("Card Holder Name: ");
        string cardHolderName = Console.ReadLine() ?? string.Empty;;
        Console.Write("Expiry Date (MM/YY): ");
        string expiry = Console.ReadLine() ?? string.Empty;;
        Console.Write("CVV: ");
        string cvv = Console.ReadLine() ?? string.Empty;;

        if (string.IsNullOrEmpty(cardNumber) || string.IsNullOrEmpty(cardHolderName) || string.IsNullOrEmpty(expiry) || string.IsNullOrEmpty(cvv))
        {
            Console.WriteLine("Payment details cannot be empty. Please try again.");
            return;
        }

        var paymentInfo = new PaymentInfo
        {
            CardNumber = cardNumber,
            CardHolderName = cardHolderName,
            ExpiryDate = expiry,
            CVV = cvv
        };

        if (_paymentService.ProcessPayment(paymentInfo, cart, _customer))
        {
            Console.WriteLine("Payment successful! Thank you for your purchase.");
            _cartService.ClearCart();  // Clear the cart after successful payment
        }
        else
        {
            Console.WriteLine("Payment failed. Please try again.");
        }
    }
    
}
