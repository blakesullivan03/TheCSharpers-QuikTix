import React, { useEffect, useState } from "react";
import { useParams } from "react-router-dom";
import { getMovieById } from "../apiService";

function MovieDetailsPage() {
  const [movie, setMovie] = useState(null);
  const { id } = useParams();

  useEffect(() => {
    getMovieById(id).then(setMovie).catch((error) => console.error("Error fetching movie details:", error));
  }, [id]);

  if (!movie) return <div>Loading...</div>;

  return (
    <div>
      <h1>{movie.title}</h1>
      <p>{movie.genre}</p>
      <p>{movie.description}</p>
      <p>Rating: {movie.rating}</p>
      <p>Release Date: {new Date(movie.releaseDate).toLocaleDateString()}</p>
      <p>Tickets Available: {movie.ticketCount}</p>
    </div>
  );
}

export default MovieDetailsPage;
