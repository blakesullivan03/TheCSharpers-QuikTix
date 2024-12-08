/*using TheCSharpers_QuikTix.Models;
namespace TheCSharpers_QuikTix.Services.Interfaces
{
    public interface ICartService
    {
        Cart DisplayCart();
        void AddTicketToCart(int id, Movie movie, int quantity, decimal price);
        void RemoveTicketFromCart(Movie movie);
        void ClearCart();
    }

    
}*/

using TheCSharpers_QuikTix.Models;
using System.Collections.Generic;

public interface ICartService
{
    void AddToCart(Cart item);  // Adds a cart item
    IEnumerable<Cart> GetCartItems();  // Returns a list of all cart items
    Cart GetCartItem(int movieId, string ticketType);  // Fetch a specific cart item
    void UpdateCartItem(int movieId, string ticketType, Cart updatedItem);  // Update a specific cart item
    void RemoveFromCart(int movieId, string ticketType);  // Removes a cart item
    void ClearCart();  // Clears the cart
    decimal CalculateTotal();  // Calculates total price of all items in the cart
}
