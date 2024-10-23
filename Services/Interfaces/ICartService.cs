using TheCSharpers_QuikTix.Models;
namespace TheCSharpers_QuikTix.Services.Interfaces
{
    public interface ICartService
    {
        Cart DisplayCart();
        void AddTicketToCart(int id, Movie movie, int quantity, decimal price);
        void RemoveTicketFromCart(Movie movie);
        void ClearCart();
    }

    
}