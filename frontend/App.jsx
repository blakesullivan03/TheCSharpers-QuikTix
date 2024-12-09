import React from 'react';
import { BrowserRouter as Router, Route, Routes } from 'react-router-dom';
import LandingPage from './pages/LandingPage';
import MoviePage from './pages/MoviePage';
import CartPage from './pages/CartPage';
import CartButton from './components/CartButton';

function App() {
  return (
    <Router>
      <div>
        <CartButton />  {/* Always visible */}
        <Routes>
          <Route path="/" element={<LandingPage />} />
          <Route path="/movies/:id" element={<MoviePage />} />
          <Route path="/cart" element={<CartPage />} />
        </Routes>
      </div>
    </Router>
  );
}

export default App;
