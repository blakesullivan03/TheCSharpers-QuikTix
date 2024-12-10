import React, { useEffect, useState } from "react";
import { useNavigate } from "react-router-dom";
import { getMovies } from "../apiService";


function MovieListPage() {
  const [movies, setMovies] = useState([]);
  const navigate = useNavigate();


  useEffect(() => {
    getMovies()
      .then((movies) => {
        setMovies(movies);
      })
      .catch((error) => {
        console.error("Error fetching movies:", error);
      });
  }, []);


  return (
    <div>
      <h1>Available Movies</h1>
      <ul>
        {movies.map((movie) => (
          <li key={movie.id} style={{ marginBottom: "20px" }}>
              <div>
                <h2 style={{ display: "inline-block", marginRight: "10px" }}>
                  {movie.title}
                </h2>
                <button
                  style={{
                    marginLeft: "10px",
                    padding: "5px 10px",
                    backgroundColor: "#007bff",
                    color: "white",
                    border: "none",
                    cursor: "pointer",
                  }}
                  onClick={() => navigate(`/movies/${movie.id}`)}
                >
                  Buy Tickets
                </button>
                <button
                  style={{
                    marginLeft: "10px",
                    padding: "5px 10px",
                    backgroundColor: "#007bff",
                    color: "white",
                    border: "none",
                    cursor: "pointer",
                  }}
                  onClick={() => navigate(`/movies/${movie.id}/reviews`)}
                >
                  Add Review
                </button>
                <p>{movie.description}</p>
              </div>
          </li>
        ))}
      </ul>
    </div>
  );
}


export default MovieListPage;
