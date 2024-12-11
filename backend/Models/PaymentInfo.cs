namespace TheCSharpers_QuikTix.Models
{
    public class PaymentInfo
    {
        public int PaymentInfoId { get; set; }
        public int CartId { get; set; }
        public int CustomerId { get; set; }
        public string? CardHolderName { get; set; } 
        public string? CardNumber { get; set; } 
        public string? ExpiryDate { get; set; }
        public string? CVV { get; set; }
        public string BillingAddress { get; set; } = "1234 Main St, Seattle, WA 98101";

    }
}