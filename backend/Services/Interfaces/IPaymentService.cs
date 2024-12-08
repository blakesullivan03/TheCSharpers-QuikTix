using System;
using TheCSharpers_QuikTix.Models;

namespace TheCSharpers_QuikTix.Services.Interfaces
{
    public interface IPaymentService
    {
        // Process payment for the cart
        bool ProcessPayment(PaymentInfo paymentInfo, Cart cart, Customer customer);

        // Validate the provided payment information
        bool ValidatePaymentInfo(PaymentInfo paymentInfo);
    }
}