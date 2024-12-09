// src/components/Checkout.js
import React, { useState } from 'react';
import { useNavigate } from 'react-router-dom';

/* Simulating cart data
const cartData = {
  tickets: [
    { type: 'Adult', quantity: 2, price: 10 },
    { type: 'Child', quantity: 3, price: 5 },
  ]
};*/

const PaymentPage = () => {
  const [cardNumber, setCardNumber] = useState('');
  const [cardHolderName, setCardHolderName] = useState('');
  const [expiryDate, setExpiryDate] = useState('');
  const [cvv, setCvv] = useState('');
  const [paymentResult, setPaymentResult] = useState('');
  const [errors, setErrors] = useState({});
  const navigate = useNavigate();

  //const totalAmount = cartData.tickets.reduce((acc, ticket) => acc + ticket.quantity * ticket.price, 0);
  //const totalWithTaxes = totalAmount * 0.07 + totalAmount;

  const validateCardNumber = (number) => /\d{4}-\d{4}-\d{4}-\d{4}/.test(number);
  const validateExpiryDate = (date) => /^\d{2}\/\d{2}$/.test(date);
  const validateCVV = (cvvValue) => /^\d{3}$/.test(cvvValue);

  const handleSubmit = (e) => {
    e.preventDefault();
    const newErrors = {};

    if (!validateCardNumber(cardNumber)) newErrors.cardNumber = 'Invalid card number. Format should be 1234-1234-1234-1234.';
    if (!cardHolderName.trim()) newErrors.cardHolderName = 'Card holder name cannot be empty.';
    if (!validateExpiryDate(expiryDate)) newErrors.expiryDate = 'Invalid expiry date. Format should be MM/YY.';
    if (!validateCVV(cvv)) newErrors.cvv = 'Invalid CVV. Must be exactly 3 digits.';

    if (Object.keys(newErrors).length > 0) {
      setErrors(newErrors);
      return;
    }

    // Simulate payment processing here
    const paymentSuccess = processPayment();
    if (paymentSuccess) {
      setPaymentResult('Payment successful! Thank you for your purchase.');
    } else {
      setPaymentResult('Payment failed. Please try again.');
    }
  };

  const processPayment = () => {
    // Here, you can integrate with your backend API for payment processing
    // For now, we are just simulating a successful payment
    return true;
  };

return (
    <div className="checkout-container">
        <h1>QuikTix Checkout</h1>

        <div className="cart-summary">
            <h2>Cart Summary</h2>
            {/* <p>Total Cost: ${totalAmount.toFixed(2)}</p>
            <p>Total Cost with Taxes: ${(totalWithTaxes).toFixed(2)}</p> */}
        </div>

        <h3>Enter Payment Details</h3>

        <form onSubmit={handleSubmit} id="paymentForm">
            <div className="input-group">
                <label htmlFor="cardNumber">Card Number:</label>
                <input
                    type="text"
                    id="cardNumber"
                    value={cardNumber}
                    onChange={(e) => setCardNumber(e.target.value)}
                    placeholder="1234-1234-1234-1234"
                    required
                />
                {errors.cardNumber && <span className="error">{errors.cardNumber}</span>}
            </div>

            <div className="input-group">
                <label htmlFor="cardHolderName">Card Holder Name:</label>
                <input
                    type="text"
                    id="cardHolderName"
                    value={cardHolderName}
                    onChange={(e) => setCardHolderName(e.target.value)}
                    required
                />
                {errors.cardHolderName && <span className="error">{errors.cardHolderName}</span>}
            </div>

            <div className="input-group">
                <label htmlFor="expiryDate">Expiry Date (MM/YY):</label>
                <input
                    type="text"
                    id="expiryDate"
                    value={expiryDate}
                    onChange={(e) => setExpiryDate(e.target.value)}
                    placeholder="MM/YY"
                    required
                />
                {errors.expiryDate && <span className="error">{errors.expiryDate}</span>}
            </div>

            <div className="input-group">
                <label htmlFor="cvv">CVV:</label>
                <input
                    type="text"
                    id="cvv"
                    value={cvv}
                    onChange={(e) => setCvv(e.target.value)}
                    placeholder="123"
                    required
                />
                {errors.cvv && <span className="error">{errors.cvv}</span>}
            </div>

            <button type="submit" id="submitBtn">Submit Payment</button>
        </form>

        {paymentResult && <div className="payment-result">{paymentResult}</div>}

        <button id="exitBtn" onClick={() => navigate("/")}>Exit</button>
    </div>
);
};

export default PaymentPage;

/*using System;
using System.Text.RegularExpressions;
using TheCSharpers_QuikTix.Services;
using TheCSharpers_QuikTix.Models;

public class PaymentPage
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
}*/
