namespace TheCSharpers_QuikTix.Models
{
    public class Customer
    {
        public int CustomerId { get; set; }                 
        public string? Name { get; set; }             
        public string? Email { get; set; }           
        public string? PhoneNumber { get; set; }      
        public List<Ticket> PurchaseHistory { get; set; } = new List<Ticket>();  

    }
}