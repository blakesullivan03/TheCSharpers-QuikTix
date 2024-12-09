import React, { useState } from 'react';
import { useNavigate } from 'react-router-dom';  // Import the useNavigate hook
import { addTicketToCart } from '../apiService';  // Import the API call function

const Showtime = ({ showtime, movieId }) => {
    const [adultTickets, setAdultTickets] = useState(0);
    const [childTickets, setChildTickets] = useState(0);
    const navigate = useNavigate();  // Initialize the navigate function

    const addToCart = async () => {
        try {
            // Log the Tickets to the Console
            console.log('Adding to cart:', {
                movieId,
                showtimeId: showtime.id,
                adultTickets,
                childTickets
            });

            // Call the API to add tickets to the cart
            await addTicketToCart(movieId, {
                showtimeId: showtime.id,
                adultTickets,
                childTickets
            });

            alert('Tickets added to cart');
            navigate('/cart');  // Navigate to the cart page
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
