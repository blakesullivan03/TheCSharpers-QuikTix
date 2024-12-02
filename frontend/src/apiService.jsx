/*
* Accesses the API's from the Backend
*/

import axios from "axios";

const api = axios.create({
  baseURL: "http://localhost:5056/api", // Change this if your backend is on a different port
});

export const getMovies = async () => {
  const response = await api.get("/Movies/get");
  return response.data;
};

export const addTicketToCart = async (movieId, quantity) => {
  await api.post("/cart/add", { movieId, quantity });
};

export const getCart = async () => {
  const response = await api.get("/Cart/getcart");
  return response.data;
};

export const removeTicketFromCart = async (ticketId) => {
  await api.delete(`/cart/removeTicket/${ticketId}`);
};
