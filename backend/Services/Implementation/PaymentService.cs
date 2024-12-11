using System.Linq;
using TheCSharpers_QuikTix.Models;
using System.Text.RegularExpressions;
using TheCSharpers_QuikTix.Services.Interfaces;
public class PaymentService : IPaymentService
{

    private readonly QuikTixDbContext _context;

    public PaymentService(QuikTixDbContext context)
    {
        _context = context;
    }

    // Process payment for the cart
    public bool ProcessPayment(PaymentInfo paymentInfo, Cart cart, Customer customer)
    {
        if (ValidatePaymentInfo(paymentInfo))
        {
            // Simulate payment success/failure logic
            if (true)  // Payment succeeds
            {
                // Add Purchase History
                Console.WriteLine(cart.Tickets.Count);
                for(int i = 0; i < cart.Tickets.Count; i++)
                {
                    var id = cart.Tickets[i].Id;
                    var ticketString = id.ToString();
                        if (!string.IsNullOrEmpty(ticketString))
                        {
                            customer.PurchaseHistory.Add(" Order Confirmation Number - " + ticketString);
                        }
                }
                _context.Update(customer);
                _context.SaveChanges();
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

        if (paymentInfo.CardNumber == null || !(r1.Match(paymentInfo.CardNumber).Success))
        {
            return false;
        }

        Regex r2 = new Regex(@"^(0[1-9]|1[0-2])\/2[4-9]$");

        if (paymentInfo.ExpiryDate == null || !(r2.Match(paymentInfo.ExpiryDate).Success))
        {
            return false;
        }

        Regex r3 = new Regex(@"^\d\d\d$");

        if (paymentInfo.CVV == null || !(r3.Match(paymentInfo.CVV).Success))
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