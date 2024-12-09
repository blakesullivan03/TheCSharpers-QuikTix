import React, { useEffect, useState } from 'react';
import { useParams } from 'react-router-dom';
import { getMovieById } from '../api'; // We'll create this API call

function MoviePage() {
  const { id } = useParams();
  const [movie, setMovie] = useState(null);

  useEffect(() => {
    const fetchMovie = async () => {
      const movieDetails = await getMovieById(id);
      setMovie(movieDetails);
    };

    fetchMovie();
  }, [id]);

  if (!movie) return <div>Loading...</div>;

  return (
    <div>
      <h2>{movie.title}</h2>
      <img src={movie.imagePath} alt={movie.title} />
      <p>{movie.description}</p>
      <button>Add to Cart</button>
    </div>
  );
}

export default MoviePage;
