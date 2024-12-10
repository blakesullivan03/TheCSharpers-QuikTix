import React, { useEffect, useState } from "react";
import { useParams, useNavigate } from "react-router-dom";
import { getReviews } from "../apiService"; // Ensure this points to your API file

const MovieReviewsPage = () => {
  const { movieId } = useParams(); // Get movieId from the route
  const [reviews, setReviews] = useState([]);
  const [movieTitle, setMovieTitle] = useState(""); // Optional: Set movie title if available
  const [loading, setLoading] = useState(true);
  const [error, setError] = useState(null);
  const navigate = useNavigate();

  // Fetch reviews for the movie
  useEffect(() => {
    const fetchReviews = async () => {
      try {
        setLoading(true);
        const fetchedReviews = await getReviews(movieId);
        setReviews(fetchedReviews);
        // Optionally set the movie title if returned in fetchedReviews
        if (fetchedReviews?.length > 0) {
          setMovieTitle(fetchedReviews[0].movieTitle || "Movie"); // Update this based on your API response
        }
      } catch (err) {
        setError("Failed to fetch reviews. Please try again.");
        console.error("Error fetching reviews:", err);
      } finally {
        setLoading(false);
      }
    };

    fetchReviews();
  }, [movieId]);

  return (
    <div className="movie-reviews-page">
      <h1>{movieTitle} Reviews</h1>
      {loading && <p>Loading reviews...</p>}
      {error && <p style={{ color: "red" }}>{error}</p>}
      {!loading && reviews.length === 0 && (
        <p>No reviews available for this movie.</p>
      )}
      {!loading && reviews.length > 0 && (
        <div className="reviews-container">
          {reviews.map((review) => (
            <div className="review-item" key={review.id}>
              <h3>{review.reviewerName}</h3>
              <p>
                <strong>Rating:</strong> {review.rating} / 10
              </p>
              <p>
                <strong>Comment:</strong> {review.comment}
              </p>
            </div>
          ))}
        </div>
      )}
      <button
        className="back-button"
        onClick={() => navigate(-1)} // Navigate back to the previous page
      >
        Back
      </button>
    </div>
  );
};

export default MovieReviewsPage;
