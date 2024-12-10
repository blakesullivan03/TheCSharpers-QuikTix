import React, { useState } from "react";
import { useParams, useNavigate } from "react-router-dom";
import { addReview } from "../apiService";

const AddReviewPage = ({ movieId }) => {

  const [reviewerName, setReviewerName] = useState("");
  const [rating, setRating] = useState(1);
  const [comment, setComment] = useState("");
  const [successMessage, setSuccessMessage] = useState("");
  const [errorMessage, setErrorMessage] = useState("");

  movieId = useParams();
  const navigate = useNavigate();

  const handleSubmit = async (e) => {
    e.preventDefault();
    setSuccessMessage("");
    setErrorMessage("");

    const review = {
      reviewerName,
      rating,
      comment,
    };

    try {
      const response = await addReview(movieId.movieId, review);
      setSuccessMessage("Review added successfully!");
      setReviewerName("");
      setRating(1);
      setComment("");
      navigate(`/movies/${movieId.movieId}/reviews`);
    } catch (error) {
      setErrorMessage("Failed to add review. Please try again.");
      console.error("Error adding review:", error);
    }
  };

  return (
    <div style={{ maxWidth: "600px", margin: "auto", padding: "20px" }}>
      <h2>Add a Review</h2>
      {successMessage && <p style={{ color: "green" }}>{successMessage}</p>}
      {errorMessage && <p style={{ color: "red" }}>{errorMessage}</p>}
      <form onSubmit={handleSubmit}>
        <div style={{ marginBottom: "10px" }}>
          <label htmlFor="reviewerName">Your Name:</label>
          <input
            type="text"
            id="reviewerName"
            value={reviewerName}
            onChange={(e) => setReviewerName(e.target.value)}
            required
            style={{ width: "100%", padding: "8px", marginTop: "5px" }}
          />
        </div>
        <div style={{ marginBottom: "10px" }}>
          <label htmlFor="rating">Rating (1-5):</label>
          <select
            id="rating"
            value={rating}
            onChange={(e) => setRating(Number(e.target.value))}
            required
            style={{ width: "100%", padding: "8px", marginTop: "5px" }}
          >
            {[1, 2, 3, 4, 5].map((num) => (
              <option key={num} value={num}>
                {num}
              </option>
            ))}
          </select>
        </div>
        <div style={{ marginBottom: "10px" }}>
          <label htmlFor="comment">Comment:</label>
          <textarea
            id="comment"
            value={comment}
            onChange={(e) => setComment(e.target.value)}
            rows="5"
            required
            style={{ width: "100%", padding: "8px", marginTop: "5px" }}
          />
        </div>
        <button type="submit" style={{ padding: "10px 20px", cursor: "pointer" }}>
          Submit Review
        </button>
      </form>
    </div>
  );
};

export default AddReviewPage;
