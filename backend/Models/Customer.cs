namespace TheCSharpers_QuikTix.Models
{
    public class Customer
    {
        public int Id { get; set; }                 
        public string Name { get; set; }             
        public string Email { get; set; }           
        public string PhoneNumber { get; set; }      
        public Cart Cart { get; set; }               
        public List<Ticket> PurchaseHistory { get; set; } = new List<Ticket>();  
    

        // Constructor
        public Customer(int id, string name, string email, string phoneNumber)
        {
            Id = id;
            Name = name;
            Email = email;
            PhoneNumber = phoneNumber;
            Cart = new Cart();
            PurchaseHistory = new List<Ticket>();
        }

    }
}