import React, { useState, useEffect } from "react";
import { useNavigate } from "react-router-dom";
import { getCart, removeTicketFromCart } from "../apiService";

function CartPage() {
  const [cart, setCart] = useState([]);
  const navigate = useNavigate();

  useEffect(() => {
    getCart()
      .then((data) => setCart(data))
      .catch((error) => console.error("Failed to fetch cart data:", error));
  }, []);

  const handleRemoveFromCart = (ticketId) => {
    removeTicketFromCart(ticketId)
      .then(() => {
        setCart((prevCart) => prevCart.filter((ticket) => ticket.cartId !== ticketId));
      })
      .catch((error) => console.error("Failed to remove ticket:", error));
  };

  const totalPrice = cart.reduce(
    (total, ticket) => total + ticket.price * ticket.quantity,
    0
  );

  if (cart.length === 0) {
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
        {cart.map((ticket) => (
          <li key={ticket.cartId}>
            <div>
              <h3>{ticket.movieTitle}</h3>
              <p>Ticket Type: {ticket.ticketType}</p>
              <p>Quantity: {ticket.quantity}</p>
              <p>Price per Ticket: ${ticket.price.toFixed(2)}</p>
              <p>Total: ${(ticket.price * ticket.quantity).toFixed(2)}</p>
              <button onClick={() => handleRemoveFromCart(ticket.cartId)}>
                Remove
              </button>
            </div>
          </li>
        ))}
      </ul>
      <h3>Total Price: ${totalPrice.toFixed(2)}</h3>
      <button onClick={() => navigate("/paymentpage")}>Proceed to Checkout</button>
    </div>
  );
}

export default CartPage;
