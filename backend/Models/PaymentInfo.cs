namespace TheCSharpers_QuikTix.Models
{
    public class PaymentInfo
    {
        public int PaymentInfoId { get; set; }
        public string CardHolderName { get; set; } = "John Doe";
        public string CardNumber { get; set; } = "1234 5678 9012 3456";
        public string ExpiryDate { get; set; } = "01/23";
        public string CVV { get; set; } = "123";
        public string BillingAddress { get; set; } = "1234 Main St, Seattle, WA 98101";

    }
}