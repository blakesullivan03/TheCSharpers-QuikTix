import React from "react";
import { BrowserRouter as Router, Route, Routes } from "react-router-dom";
import WelcomePage from "./pages/WelcomePage";  // Ensure path is correct
import MovieListPage from "./pages/MovieListPage";  // Ensure path is correct
import MovieDetailsPage from "./pages/MovieDetailsPage";  // Ensure path is correct
import CartPage from "./pages/CartPage";  // Ensure path is correct
import NavBar from "./components/NavBar";  // Ensure path is correct

function App() {
  return (
    <Router>
      <NavBar />  {/* This will show the navigation bar on all pages */}
      <Routes>
        <Route path="/" element={<WelcomePage />} />  {/* Home/Welcome page */}
        <Route path="/movies" element={<MovieListPage />} />  {/* List of movies */}
        <Route path="/movies/:movieId" element={<MovieDetailsPage />} />  {/* Movie details based on ID */}
        <Route path="/cart" element={<CartPage />} />  {/* Cart page */}
      </Routes>
    </Router>
  );
}

export default App;
