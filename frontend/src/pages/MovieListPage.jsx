import React, { useEffect, useState } from "react";
import { useNavigate } from "react-router-dom";
import { getMovies } from "../apiService";
import "../pages.css/MovieListPage.css";
import imagePath from './assets/image1.png';
import imagePath2 from './assets/starwars.jpg';
import imagePath3 from './assets/matrix.jpg';

const MovieListPage = () => {
  const [movies, setMovies] = useState([]);
  const [filteredMovies, setFilteredMovies] = useState([]);
  const [sortOption, setSortOption] = useState("Original");
  const [selectedDate, setSelectedDate] = useState("");
  const [carouselIndex, setCarouselIndex] = useState(0);
  const imageMap = {
    1: imagePath2,
    2: imagePath3,
  };
  const navigate = useNavigate();

  // Fetch movies on component mount
  useEffect(() => {
    getMovies()
      .then((movies) => {
        setMovies(movies);
        setFilteredMovies(movies);
      })
      .catch((error) => {
        console.error("Error fetching movies:", error);
      });
  }, []);

  // Carousel Auto-Scroll Logic
  useEffect(() => {
    const interval = setInterval(() => {
      setCarouselIndex((prevIndex) => (prevIndex + 1) % movies.length);
    }, 3000); // Change every 3 seconds

    return () => clearInterval(interval); // Cleanup interval on component unmount
  }, [movies]);

  // Handle sort option change
  const handleSortChange = (e) => {
    const selectedOption = e.target.value;
    setSortOption(selectedOption);

    let sortedList = [...filteredMovies];
    switch (selectedOption) {
      case "AtoZ":
        sortedList.sort((a, b) => a.title.localeCompare(b.title));
        break;
      case "ZtoA":
        sortedList.sort((a, b) => b.title.localeCompare(a.title));
        break;
      case "EarliestShowtime":
        sortedList.sort(
          (a, b) =>
            new Date(a.showtimes[0]?.startTime || Infinity) -
            new Date(b.showtimes[0]?.startTime || Infinity)
        );
        break;
      case "BestRated":
        sortedList.sort((a, b) => b.rating - a.rating);
        break;
      case "Popular":
        sortedList.sort((a, b) => (b.popularity || 0) - (a.popularity || 0));
        break;
      default:
        sortedList = [...filteredMovies];
    }
    setFilteredMovies(sortedList);
  };

  // Filter by date
  const handleDateChange = (e) => {
    const selectedDate = e.target.value;
    setSelectedDate(selectedDate);

    if (selectedDate) {
      const filteredList = movies.filter((movie) =>
        movie.showtimes.some(
          (showtime) =>
            new Date(showtime.startTime).toDateString() ===
            new Date(selectedDate).toDateString()
        )
      );
      setFilteredMovies(filteredList);
    } else {
      setFilteredMovies(movies);
    }
  };


  return (
    <div className="movie-list-page">
      {/* Carousel Section */}
      <div className="carousel-container">
        <div
          className="carousel"
          style={{
            transform: `translateX(-${carouselIndex * 100}%)`,
            transition: "transform 0.5s ease-in-out",
            display: "flex",
          }}
        >
          {movies.map((movie, index) => (
            <img
              src={imageMap[movie.id] || imagePath}
              key={index}
              alt={movie.title}
              className="carousel-item"
            />
          ))}
        </div>
      </div>

      {/* Calendar View */}
      <div className="calendar-container">
        <label htmlFor="filter-date">Filter by Date:</label>
        <input
          type="date"
          id="filter-date"
          value={selectedDate}
          onChange={handleDateChange}
        />
      </div>

      {/* Sorting Dropdown */}
      <div className="sorting-container">
        <label htmlFor="sort-by">Sort Movies By:</label>
        <select
          id="sort-by"
          className="sort-dropdown"
          value={sortOption}
          onChange={handleSortChange}
        >
          <option value="Original">Original Order</option>
          <option value="AtoZ">Alphabetical A to Z</option>
          <option value="ZtoA">Alphabetical Z to A</option>
          <option value="EarliestShowtime">Earliest Showtime</option>
          <option value="BestRated">Best Rated</option>
          <option value="Popular">Most Popular</option>
        </select>
      </div>

      {/* Movie List Section */}
      <div className="movie-list">
        {filteredMovies.map((movie) => (
          <div className="movie-item" key={movie.id}>
            <div className="movie-poster-section">
              <img
                src={imageMap[movie.id] || imagePath}
                alt={movie.title}
                className="movie-poster"
              />
            </div>
            <div className="movie-details">
              <h2>{movie.title}</h2>
              <p><strong>Genre:</strong> {movie.genre}</p>
              <p><strong>Description:</strong> {movie.description}</p>
              <p><strong>Rating:</strong> {movie.rating || "N/A"} / 10</p>
              <p><strong>Popularity:</strong> {movie.popularity || "N/A"}</p>
              <div className="showtimes">
                <h3>Showtimes:</h3>
                {movie.showtimes.length > 0 ? (
                  movie.showtimes.map((showtime) => (
                    <div key={showtime.id} className="showtime">
                      <details>
                        <summary>
                          {new Date(showtime.startTime).toLocaleString()}
                        </summary>
                        <p>Adult Tickets: {showtime.adultTicketCount}</p>
                        <p>Child Tickets: {showtime.childTicketCount}</p>
                        <button
                          onClick={() =>
                            navigate(`/movies/${movie.id}`)
                          }
                          className="book-now-button"
                        >
                          Book Now
                        </button>
                      </details>
                    </div>
                  ))
                ) : (
                  <p>No Showtimes Available</p>
                )}
              </div>
              <div className="movie-actions">
                <button onClick={() => navigate(`/movies/${movie.id}/add-review`)}>
                  Add Review
                </button>
                <button onClick={() => navigate(`/movies/${movie.id}/reviews`)}>
                  View Reviews
                </button>
              </div>
            </div>
          </div>
        ))}
      </div>
    </div>
  );
};

export default MovieListPage;
