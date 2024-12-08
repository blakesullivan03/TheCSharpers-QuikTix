import React, { useState, useEffect } from "react";
import { useParams, useNavigate } from "react-router-dom";
import { getMovies, addTicketToCart } from "../apiService";

function MovieDetailsPage() {
  const navigate = useNavigate();
  const { movieId } = useParams();
  const [movie, setMovie] = useState(null);
  const [quantity, setQuantity] = useState(1);

  useEffect(() => {
    getMovies().then((movies) => {
      const selectedMovie = movies.find((movie) => movie.id === parseInt(movieId));
      setMovie(selectedMovie);
    }).catch((error) => console.error(error));
  }, [movieId]);

  const handleAddToCart = () => {
    addTicketToCart(movie.id, quantity)
      .then(() => {
        alert("Ticket added to cart");
        navigate("/cart"); // Navigate to the cart page
      })
      .catch((error) => console.error(error));
  };
  
  if (!movie) return <div>Loading...</div>;

  return (
    <div>
      <h1>{movie.title}</h1>
      <p>Genre: {movie.genre}</p>
      <p>{movie.description}</p>
      <p>Show Time: {movie.releaseDate} </p>
      <p>Available Tickets: {movie.ticketCount} </p>
      <input
        type="number"
        value={quantity}
        onChange={(e) => setQuantity(Number(e.target.value))}
        min="1"
        max={movie.availableTickets}
      />
      <button onClick={handleAddToCart}>Add to Cart</button>
    </div>
  );
}

export default MovieDetailsPage;
