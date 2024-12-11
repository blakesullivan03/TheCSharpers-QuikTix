import React from "react";
import { BrowserRouter as Router, Route, Routes } from "react-router-dom";
import WelcomePage from "./pages/WelcomePage";
import MovieListPage from "./pages/MovieListPage";
import MovieDetailsPage from "./pages/MovieDetailsPage";
import AddReviewPage from "./pages/AddReviewPage";
import ReviewPage from "./pages/ReviewPage";
import CartPage from "./pages/CartPage";
import PaymentPage from "./pages/PaymentPage";
import NavBar from "./components/NavBar";


function App() {
  return (
    <Router>
      <NavBar />
      <Routes>
        <Route path="/" element={<WelcomePage />} />
        <Route path="/movies" element={<MovieListPage />} />
        <Route path="/movies/:movieId" element={<MovieDetailsPage />} />
        <Route path="/movies/:movieId/add-review" element={<AddReviewPage />} />
        <Route path="/movies/:movieId/reviews" element={<ReviewPage />} />
        <Route path="/cart/:cartId" element={<CartPage />} />
        <Route path="/payment-page/:cartId" element={<PaymentPage />} />
      </Routes>
    </Router>
  );
}

export default App;
