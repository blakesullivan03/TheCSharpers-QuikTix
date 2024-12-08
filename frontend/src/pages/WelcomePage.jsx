import React from "react";
import { Link } from "react-router-dom";

function WelcomePage() {
  return (
    <div>
      <h1>Welcome to QuikTix</h1>
      <p>Your one-stop solution for movie tickets and reviews.</p>
      <Link to="/movies">Browse Movies</Link>
    </div>
  );
}

export default WelcomePage;
