using System;
using System.Collections.Generic;
using System.Linq;
using TheCSharpers_QuikTix.Models;

public class CartService : ICartService
{
    private readonly QuikTixDbContext _context;

    public CartService(QuikTixDbContext context)
    {
        _context = context;
    }

    public IEnumerable<Cart> GetCartItems()
    {
        return _context.Carts.ToList();  // Retrieve All Cart Items
    }

    public Cart GetCartItem(int movieId, string ticketType)
    {
        var item = _context.Carts.FirstOrDefault(c => c.MovieId == movieId && c.TicketType == ticketType);
        if (item == null)
        {
            throw new KeyNotFoundException($"Cart item with MovieId {movieId} and TicketType {ticketType} not found.");
        }
        return item;
    }

    public void AddToCart(Cart item)
    {
        if (item.Quantity <= 0) throw new ArgumentException("Quantity must be positive.");

        var existingItem = _context.Carts.FirstOrDefault(
            c => c.MovieId == item.MovieId && c.TicketType == item.TicketType
        );

        if (existingItem != null)
        {
            existingItem.Quantity += item.Quantity;  // Update the quantity of existing item
            _context.SaveChanges();  // Persist the change
        }
        else
        {
            _context.Carts.Add(item);  // Add new cart item
            _context.SaveChanges();
        }
    }

    public void UpdateCartItem(int movieId, string ticketType, Cart updatedItem)
    {
        var item = _context.Carts.FirstOrDefault(c => c.MovieId == movieId && c.TicketType == ticketType);
        if (item != null)
        {
            item.Quantity = updatedItem.Quantity;
            item.Price = updatedItem.Price;
            _context.SaveChanges();  // Persist the update
        }
        else
        {
            throw new KeyNotFoundException($"Cart item with MovieId {movieId} and TicketType {ticketType} not found.");
        }
    }

    public void RemoveFromCart(int movieId, string ticketType)
    {
        var item = _context.Carts.FirstOrDefault(c => c.MovieId == movieId && c.TicketType == ticketType);
        if (item != null)
        {
            _context.Carts.Remove(item);  // Remove the cart item
            _context.SaveChanges();  // Persist the removal
        }
        else
        {
            throw new KeyNotFoundException($"Cart item with MovieId {movieId} and TicketType {ticketType} not found.");
        }
    }

    public void ClearCart()
    {
        var items = _context.Carts.ToList();  // Retrieve all cart items
        _context.Carts.RemoveRange(items);  // Remove all items
        _context.SaveChanges();  // Persist the changes
    }

    public decimal CalculateTotal()
    {
        return _context.Carts.Sum(item => item.Price * item.Quantity);  // Calculate total price of items in the cart
    }
}
