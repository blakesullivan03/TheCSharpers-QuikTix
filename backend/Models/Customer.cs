namespace TheCSharpers_QuikTix.Models
{
    public class Customer
    {
        public int CustomerId { get; set; }                 
        public string? Name { get; set; }             
        public string? Email { get; set; }           
        public string? PhoneNumber { get; set; }      
        public List<String> PurchaseHistory { get; set; } = new List<String>();  

    }
}