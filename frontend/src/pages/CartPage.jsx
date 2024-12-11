import React, { useState, useEffect } from "react";
import { useNavigate, useParams } from "react-router-dom";
import { getCart, removeTicketFromCart } from "../apiService";

function CartPage() {
  const [cart, setCart] = useState({ cartId: null, tickets: [] });
  const navigate = useNavigate();
  const { cartId } = useParams();

  useEffect(() => {
    getCart(cartId)
      .then((data) => {
        console.log("Cart Data:", data);
        setCart(data);
      })
      .catch((error) => console.error("Failed to fetch cart data:", error));
  }, [cartId]);

  const handleRemoveFromCart = (cartId, ticketId) => {
    removeTicketFromCart(cartId, ticketId)
      .then(() => {
        setCart((prevCart) => ({
          ...prevCart,
          tickets: prevCart.tickets.filter((ticket) => ticket.id !== ticketId),
        }));
      })
      .catch((error) => console.error("Failed to remove ticket:", error));
  };

  // Calculate Total Price
  const totalPrice = cart.tickets.reduce(
    (total, ticket) => total + ticket.price * ticket.quantity,
    0
  );

  if (cart.tickets.length === 0) {
    return (
      <div>
        <h2>Your Cart is Empty</h2>
        <button onClick={() => navigate("/")}>Go Back to Movies</button>
      </div>
    );
  }

  return (
    <div>
      <h1>Your Cart</h1>
      <ul>
        {cart.tickets.map((ticket) => (
          <li key={ticket.id}>
            <div>
              <h3>Movie ID: {ticket.movieId}</h3>
              <p>Ticket Type: {ticket.ticketType}</p>
              <p>Quantity: {ticket.quantity}</p>
              <p>Price per Ticket: ${ticket.price.toFixed(2)}</p>
              <p>Total: ${(ticket.price * ticket.quantity).toFixed(2)}</p>
              <button onClick={() => handleRemoveFromCart(cart.cartId, ticket.id)}>
                Remove
              </button>
            </div>
          </li>
        ))}
      </ul>
      <h3>Total Price: ${totalPrice.toFixed(2)}</h3>
      <button onClick={() => navigate(`/payment-page/${cartId}`)}>Proceed to Checkout</button>
    </div>
  );
}

export default CartPage;
