import React, { useEffect, useState } from "react";
import { Link } from "react-router-dom";
import { getMovies } from "../apiService";

function MovieListPage() {
  const [movies, setMovies] = useState([]);

  useEffect(() => {
    getMovies().then(setMovies).catch((error) => console.error("Error fetching movies:", error));
  }, []);

  return (
    <div>
      <h1>Available Movies</h1>
      <ul>
        {movies.map((movie) => (
          <li key={movie.id} style={{ marginBottom: "20px" }}>
            <h3>{movie.title}</h3>
            <p><strong>Genre:</strong> {movie.genre}</p>
            <p><strong>Description:</strong> {movie.description}</p>
            <p><strong>Rating:</strong> {movie.rating}</p>
            <p><strong>Release Date:</strong> {new Date(movie.releaseDate).toLocaleDateString()}</p>
            <p><strong>Tickets Available:</strong> {movie.ticketCount}</p>
            <img src={movie.imagePath} alt={movie.title} style={{ width: "150px", height: "auto" }} />
            <Link to={`/Movies/${movie.id}`}>View Details</Link>
          </li>
        ))}
      </ul>
    </div>
  );
}

export default MovieListPage;
