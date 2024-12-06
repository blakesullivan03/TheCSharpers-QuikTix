/*using System.Linq;
using TheCSharpers_QuikTix.Models;
using System.Text.RegularExpressions;
using TheCSharpers_QuikTix.Services.Interfaces;
public class PaymentService : IPaymentService
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
        if (string.IsNullOrWhiteSpace(paymentInfo.CardNumber) | string.IsNullOrWhiteSpace(paymentInfo.ExpiryDate) | string.IsNullOrWhiteSpace(paymentInfo.CVV) | string.IsNullOrWhiteSpace(paymentInfo.CardHolderName))
        {
            return false;
        }

        Regex r1 = new Regex(@"^\d\d\d\d-\d\d\d\d-\d\d\d\d-\d\d\d\d$");

        if (!(r1.Match(paymentInfo.CardNumber).Success))
        {
            return false;
        }

        Regex r2 = new Regex(@"^(0[1-9]|1[0-2])\/2[4-9]$");

        if (!(r2.Match(paymentInfo.ExpiryDate).Success))
        {
            return false;
        }

        Regex r3 = new Regex(@"^\d\d\d$");

        if (!(r3.Match(paymentInfo.CVV).Success))
        {
            return false;
        }

        return true;
    }

    bool IPaymentService.ValidatePaymentInfo(PaymentInfo paymentInfo)
    {
        throw new NotImplementedException();
    }
}
*/