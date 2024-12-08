using System;
using System.Text.RegularExpressions;
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
        var totalAmount = cart.Tickets.Sum(t => t.Quantity * t.Price);
        Console.WriteLine($"Total Cost: {totalAmount}");
        Console.WriteLine($"Total Cost with Taxes: {(totalAmount * 0.07) + totalAmount}");
        Console.WriteLine();

        Console.WriteLine("Enter Payment Details:");

        // Validate card number format (1234-1234-1234-1234)
        string cardNumber;
        do
        {
            Console.Write("Card Number: ");
            cardNumber = Console.ReadLine() ?? string.Empty;
            if (!IsValidCardNumber(cardNumber))
                Console.WriteLine("Invalid card number. Format should be 1234-1234-1234-1234.");
        } while (!IsValidCardNumber(cardNumber));

        // Validate card holder name (non-empty)
        string cardHolderName;
        do
        {
            Console.Write("Card Holder Name: ");
            cardHolderName = Console.ReadLine() ?? string.Empty;
            if (string.IsNullOrWhiteSpace(cardHolderName))
                Console.WriteLine("Card holder name cannot be empty.");
        } while (string.IsNullOrWhiteSpace(cardHolderName));

        // Validate expiry date format (MM/YY) with valid month and year
        string expiry;
        do
        {
            Console.Write("Expiry Date (MM/YY): ");
            expiry = Console.ReadLine() ?? string.Empty;
            if (!IsValidExpiryDate(expiry))
                Console.WriteLine("Invalid expiry date. Format should be MM/YY with month between 01 and 12 and year between 24 and 29.");
        } while (!IsValidExpiryDate(expiry));

        // Validate CVV (3 digits)
        string cvv;
        do
        {
            Console.Write("CVV: ");
            cvv = Console.ReadLine() ?? string.Empty;
            if (!IsValidCVV(cvv))
                Console.WriteLine("Invalid CVV. Must be exactly 3 digits.");
        } while (!IsValidCVV(cvv));

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

    public bool ExitProgram()
    {
        Console.WriteLine("Do you want to buy more tickets? (y/n): ");
        string input = (Console.ReadLine() ?? string.Empty).ToLower();

        if (input == "y")
        {
            Console.WriteLine("Redirecting to ticket purchase...");
            return false;
        }
        else if (input == "n")
        {
            Console.WriteLine("Thank you for using QuikTix. Goodbye!");
            return true;
        }
        else
        {
            Console.WriteLine("Invalid input. Exiting the program.");
            return true;
        }
    }

    // Helper method to validate card number format (1234-1234-1234-1234)
    private bool IsValidCardNumber(string cardNumber)
    {
        return Regex.IsMatch(cardNumber, @"^\d{4}-\d{4}-\d{4}-\d{4}$");
    }

    // Helper method to validate expiry date format (MM/YY) with valid month and year
    private bool IsValidExpiryDate(string expiry)
    {
        if (!Regex.IsMatch(expiry, @"^\d{2}/\d{2}$"))
            return false;

        var parts = expiry.Split('/');
        int month = int.Parse(parts[0]);
        int year = int.Parse(parts[1]);

        return month >= 1 && month <= 12 && year >= 24 && year <= 29;
    }

    // Helper method to validate CVV (3 digits)
    private bool IsValidCVV(string cvv)
    {
        return Regex.IsMatch(cvv, @"^\d{3}$");
    }
}
