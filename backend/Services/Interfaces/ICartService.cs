using TheCSharpers_QuikTix.Models;
namespace TheCSharpers_QuikTix.Services
{
    public interface ICartService
    {
        Cart CreateCart(int movieId, string movieTitle, string ticketType, int quantity, decimal price);
        void AddTicketToCart(int cartId, Ticket ticket);
        Cart GetCart(int cartId);
        void UpdateCart(int cartId, int newQuantity, decimal newPrice);
        void DeleteCart(int cartId);
    }
}
