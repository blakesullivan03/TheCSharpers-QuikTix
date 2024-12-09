import React, { useEffect, useState } from 'react';
import { Link } from 'react-router-dom';
import { getMovies } from '../api'; // We'll create this API call in a separate file.
import './LandingPage.css';

function LandingPage() {
  const [movies, setMovies] = useState([]);

  useEffect(() => {
    const fetchMovies = async () => {
      const movieList = await getMovies();
      setMovies(movieList);
    };

    fetchMovies();
  }, []);

  return (
    <div className="landing-page">
      <div className="carousel">
        {movies.length > 0 && movies.map(movie => (
          <img key={movie.id} src={movie.imagePath} alt={movie.title} className="carousel-image" />
        ))}
      </div>
      <div className="purchase-section">
        <button className="purchase-btn">Purchase Tickets</button>
      </div>
    </div>
  );
}

export default LandingPage;
