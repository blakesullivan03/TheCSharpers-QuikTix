// Will Handle all the Cart Related Operations
using System;
using System.Collections.Generic;
using System.Linq;
using TheCSharpers_QuikTix.Models;

public class CartService
{

    public Cart Cart { get; set; } = new Cart();

    public Cart GetCart()
    {
        if (Cart.Tickets.Count == 0)
        {
            Console.WriteLine("Your cart is empty.");
            return Cart;
        }

        Console.WriteLine("Your Cart:");
        foreach (var ticket in Cart.Tickets)
        {
            Console.WriteLine($"Movie: {ticket.Movie.Name}");
            Console.WriteLine($"Quantity: {ticket.Quantity}");
            Console.WriteLine($"Price: {ticket.Price}");
            Console.WriteLine($"Total: {ticket.Quantity * ticket.Price}");
            Console.WriteLine();
        }
        return Cart;
    }

    public void AddTicketToCart(int id, Movie movie, int quantity, float price)
    {
        var ticket = Cart.Tickets.FirstOrDefault(t => t.Movie.Id == movie.Id);
        if (ticket != null)
        {
            ticket.Quantity += quantity;
        }
        else
        {
            Cart.Tickets.Add(new Ticket(id, movie, quantity, price));

        }
    }

    public void RemoveTicketFromCart(Movie movie)
    {
        var ticket = Cart.Tickets.FirstOrDefault(t => t.Movie.Id == movie.Id);
        if (ticket != null)
            Cart.Tickets.Remove(ticket);
    }

    public void ClearCart()
    {
        Cart.Tickets.Clear();
    }
}
