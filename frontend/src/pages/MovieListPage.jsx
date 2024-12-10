import React, { useEffect, useState } from "react";
import { useNavigate } from "react-router-dom";
import { getMovies } from "../apiService";
import "../pages.css/MovieListPage.css";

const MovieListPage = () => {
  const [movies, setMovies] = useState([]);
  const [sortedMovies, setSortedMovies] = useState([]);
  const [sortOption, setSortOption] = useState("Original");
  const navigate = useNavigate();
  const [carouselIndex, setCarouselIndex] = useState(0);

  // Fetch movies on component mount
  useEffect(() => {
    getMovies()
      .then((movies) => {
        setMovies(movies);
        setSortedMovies(movies);
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

    let sortedList = [...movies];
    switch (selectedOption) {
      case "AtoZ":
        sortedList.sort((a, b) => a.title.localeCompare(b.title));
        break;
      case "ZtoA":
        sortedList.sort((a, b) => b.title.localeCompare(a.title));
        break;
      // case "ReleaseDateAsc":
      //   sortedList.sort((a, b) => new Date(a.releaseDate) - new Date(b.releaseDate));
      //   break;
      // case "ReleaseDateDesc":
      //   sortedList.sort((a, b) => new Date(b.releaseDate) - new Date(a.releaseDate));
      //   break;
      // case "DurationAsc":
      //   sortedList.sort((a, b) => a.duration - b.duration);
      //   break;
      // case "DurationDesc":
      //   sortedList.sort((a, b) => b.duration - a.duration);
      //   break;
      case "BestRated":
        sortedList.sort((a, b) => b.rating - a.rating);
        break;
      case "Popular":
        sortedList.sort((a, b) => b.popularity - a.popularity);
        break;
      default:
        sortedList = [...movies];
    }
    setSortedMovies(sortedList);
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
              key={index}
              src={movie.imagePath || "./assets/image1.png"} // Fallback to a default image
              alt={movie.title}
              className="carousel-item"
            />
          ))}
        </div>
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
          {/* <option value="ReleaseDateAsc">Release Date (Ascending)</option> */}
          {/* <option value="ReleaseDateDesc">Release Date (Descending)</option> */}
          {/* <option value="DurationAsc">Duration (Ascending)</option> */}
          {/* <option value="DurationDesc">Duration (Descending)</option> */}
          <option value="BestRated">Best Rated</option>
          <option value="Popular">Most Popular</option>
        </select>
      </div>

      {/* Movie List Section */}
      <div className="movie-list">
        {sortedMovies.map((movie) => (
          <div className="movie-item" key={movie.id}>
            <img
              src={movie.imagePath || "/assets/image1.png"}
              alt={movie.title}
              className="movie-poster"
            />
            <div className="movie-details">
              <h2>{movie.title}</h2>
              <p><strong>Genre:</strong> {movie.genre}</p>
              <p><strong>Description:</strong> {movie.description}</p>
              <p><strong>Duration:</strong> {movie.duration || "N/A"} minutes</p>
              <p><strong>Rating:</strong> {movie.rating || "N/A"} / 10</p>
              <p><strong>Tickets Available:</strong> {movie.ticketCount || "N/A"}</p>
              <div className="movie-actions">
                <button onClick={() => navigate(`/movies/${movie.id}`)}>Buy Tickets</button>
                <button onClick={() => navigate(`/movies/${movie.id}/reviews`)}>Add Review</button>
              </div>
            </div>
          </div>
        ))}
      </div>
    </div>
  );
};

export default MovieListPage;
