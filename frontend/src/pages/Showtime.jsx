import React, { useState } from 'react';
import { useNavigate, useParams } from 'react-router-dom';  // Import the useNavigate hook
import { createCart, addTicketToCart } from '../apiService';  // Import the API call function

const Showtime = ({ showtime, movieId }) => {
    const [adultTickets, setAdultTickets] = useState(0);
    const [childTickets, setChildTickets] = useState(0);
    
    const navigate = useNavigate();  // Initialize the navigate function

    const addToCart = async () => {
        try {

            // Create a New Cart
            const response = await createCart();
            console.log("Cart created:", response.cart.cartId);

            // Get the Cart ID
            const cartId = response.cart.cartId;

            // Log the Tickets to the Console
            console.log('Adding Tickets to Cart:', {
                cartId: response.cart.cartId,
                movieId,
                showtimeId: showtime.id,
                adultTickets,
                childTickets
            });

            // Call the API to add tickets to the cart
            await addTicketToCart(cartId, {
                movieId,
                showtimeId: showtime.id,
                adultTickets,
                childTickets
            });


            // Alert the User that the Tickets have been added to the Cart
            alert('Tickets added to cart');

            // Navigate to the Cart Page via ID
            navigate(`/cart/${cartId}`);
        } catch (error) {
            console.error('Error adding to cart:', error);
            alert('Failed to add tickets to cart');
        }
    };

    return (
        <div className="showtime">
            <p>{showtime.time}</p>
            <div>
                <label>Adult Tickets: </label>
                <input
                    type="number"
                    min="0"
                    value={adultTickets}
                    onChange={e => setAdultTickets(Number(e.target.value))}
                    max={showtime.adultTicketCount}
                />
                {console.log(showtime.adultTicketCount)}
            </div>
            <div>
                <label>Child Tickets: </label>
                <input
                    type="number"
                    min="0"
                    value={childTickets}
                    onChange={e => setChildTickets(Number(e.target.value))}
                    max={showtime.childTicketCount}
                />
            </div>
            <button onClick={addToCart}>Add to Cart</button>
        </div>
    );
};

export default Showtime;
