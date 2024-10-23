using System.Linq;
using TheCSharpers_QuikTix.Interfaces;
using TheCSharpers_QuikTix.Models;
public class PaymentService
{
    // Process payment for the cart
    public bool ProcessPayment(PaymentInfo paymentInfo, Cart cart, Customer customer)
    {
        if (ValidatePaymentInfo(paymentInfo))
        {
            // Simulate payment success/failure logic
            if (true)  // Payment succeeds
            {
                // Add purchased tickets to customer's purchase history
                foreach (var ticket in cart.Tickets)
                {
                    customer.PurchaseHistory.Add(ticket);
                }
                return true;
            }
        }
        return false;
    }

    // Validate the provided payment information
    private bool ValidatePaymentInfo(PaymentInfo paymentInfo)
    {
        // Implement validation logic for card number, expiry date, CVV, etc.
        if (string.IsNullOrWhiteSpace(paymentInfo.CardNumber))
        {
            return false;
        }
        else 
        {
            return true;
        }
    }
}