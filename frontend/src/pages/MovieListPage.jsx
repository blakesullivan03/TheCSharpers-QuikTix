import React, { useEffect, useState } from "react";
import { Link } from "react-router-dom";
import { getMovies } from "../apiService";

function MovieListPage() {
  const [movies, setMovies] = useState([]);

  useEffect(() => {
    getMovies()
      .then((movies) => {
        //console.log("Fetched movies:", movies);
        setMovies(movies);
      })
      .catch((error) => {
        //console.error("Error fetching movies:", error);
      });
  }, []);


  return (
    <div>
      <h1>Available Movies</h1>
      <ul>
        {movies.map((movie) => (
          <li key={movie.id}>
            <Link to={`/Movies/${movie.id}`}>
            <div>
              <h2>{movie.title}</h2>
              <p>{movie.description}</p>
            </div>
            </Link>
          </li>
        ))}
      </ul>
    </div>
  );
}

export default MovieListPage;
