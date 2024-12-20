using TheCSharpers_QuikTix.Models;

namespace TheCSharpers_QuikTix.Services
{
    public interface ICartService
    {
        Cart CreateCart(int cartId, List<Ticket> tickets);
        void AddTicketToCart(int cartId, Ticket ticket);
        Cart GetCartById(int cartId);
        void UpdateCart(int cartId, int newQuantity, decimal newPrice);
        void DeleteCart(int cartId);
    }
}