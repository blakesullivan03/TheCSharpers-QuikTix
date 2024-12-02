import React, { useState, useEffect } from "react";
import { getCart, removeTicketFromCart } from "../apiService";

function CartPage() {
  const [cart, setCart] = useState([]);

  useEffect(() => {
    getCart().then(setCart).catch((error) => console.error(error));
  }, []);

  const handleRemoveFromCart = (ticketId) => {
    removeTicketFromCart(ticketId).then(() => {
      setCart(cart.filter(ticket => ticket.id !== ticketId));
    }).catch((error) => console.error(error));
  };

  const totalPrice = cart.reduce((total, ticket) => total + ticket.totalPrice, 0);

  return (
    <div>
      <h1>Your Cart</h1>
      <ul>
        {cart.map((ticket) => (
          <li key={ticket.id}>
            {ticket.movie.title} - {ticket.quantity} tickets
            <button onClick={() => handleRemoveFromCart(ticket.id)}>Remove</button>
          </li>
        ))}
      </ul>
      <h3>Total: ${totalPrice}</h3>
      <button>Proceed to Checkout</button>
    </div>
  );
}

export default CartPage;
