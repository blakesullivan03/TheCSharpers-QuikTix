import React, { useEffect, useState } from "react";
import { Link } from "react-router-dom";
import { getMovies } from "../apiService";

function MovieListPage() {
  const [movies, setMovies] = useState([]);

  useEffect(() => {
    getMovies().then(setMovies).catch((error) => console.error(error));
  }, []);

  return (
    <div>
      <h1>Available Movies</h1>
      <ul>
        {movies.map((movie) => (
          <li key={movie.id}>
            <Link to={`/Movies/${movie.id}`}>{movie.title}</Link>
          </li>
        ))}
      </ul>
    </div>
  );
}

export default MovieListPage;
