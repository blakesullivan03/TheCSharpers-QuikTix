import React from 'react';
import { Link } from 'react-router-dom';

function CartButton() {
  return (
    <div className="cart-button">
      <Link to="/cart">Cart</Link>
    </div>
  );
}

export default CartButton;
