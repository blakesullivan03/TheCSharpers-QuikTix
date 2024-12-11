import React, { useState, useEffect } from 'react';
import { useParams } from 'react-router-dom';
import { getMovies } from '../apiService';
import Showtime from './Showtime.jsx';

const MovieDetailsPage = () => {

    const { movieId } = useParams();
    const [movie, setMovie] = useState(null);

    useEffect(() => {
      getMovies().then((movies) => {
        const selectedMovie = movies.find((movie) => movie.id === parseInt(movieId));
        setMovie(selectedMovie);
      }).catch((error) => console.error(error));
    }, [movieId]);

    if (!movie) {
        return <div>Loading...</div>;
    }

    return (
        <div>
            <h2>{movie.title}</h2>
            <p>{movie.description}</p>
            <h3>Showtimes</h3>
            {movie.showtimes.map(showtime => (
                <div key={showtime.id}>
                    <p>Start Time: {new Date(showtime.startTime).toLocaleString()}</p>
                    <Showtime showtime={showtime} movieId={movieId}/>
                </div>
            ))}
        </div>
    );
};

export default MovieDetailsPage;
