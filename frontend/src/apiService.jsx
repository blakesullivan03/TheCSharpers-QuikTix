/*
* Accesses the API's from the Backend
*/

import axios from "axios";

const api = axios.create({
  baseURL: "https://localhost:7267/api",
});

export const getMovies = async () => {
  const response = await api.get("/Movies/get");
  return response.data;
};

export const createCart = async () => {
  const response = await api.post("/Cart/create-cart", {cartId: 0});
  return response.data;
};

export const addTicketToCart = async (cartId, { movieId, showtimeId, adultTickets, childTickets }) => {
  // Send a POST request to add tickets to the cart
  const response = await api.post(`/Cart/add-to-cart/${cartId}`, {
    movieId,
    showtimeId,
    adultTickets,
    childTickets
  }, 
);
  return response.data;
};

export const getCart = async (cartId) => {
  const response = await api.get(`/Cart/get-cart/${cartId}`);
  return response.data;
};

export const getAllCarts = async () => {
  const response = await api.get("/Cart/get-all-carts");
  return response.data;
};

export const removeTicketFromCart = async (cartId) => {
  await api.delete(`/Cart/remove/${cartId}`);
}

export const clearCart = async () => {
  await api.delete("/Cart/clear");
}

export const addReview = async (movieId, review) => {
  const response = await api.post(`/Review/AddReview/${movieId}`, review);
  return response.data;
};

export const getReviews = async (movieId) => {
  const response = await api.get(`/Review/${movieId}`);
  return response.data;
};
