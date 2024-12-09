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

export const addTicketToCart = async (movieId, { showtimeId, adultTickets, childTickets }) => {
  // Send a POST request to add tickets to the cart
  const response = await api.post("/Cart/add-to-cart", {
    movieId,
    showtimeId,
    adultTickets,
    childTickets
  }, 
);
  return response.data;
};

export const getCart = async () => {
  const response = await api.get("/Cart/get-cart");
  return response.data;
};

export const removeTicketFromCart = async (cartId) => {
  await api.delete(`/Cart/remove/${cartId}`);
}

export const clearCart = async () => {
  await api.delete("/Cart/clear");
}
