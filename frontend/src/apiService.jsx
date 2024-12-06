import axios from "axios";

const api = axios.create({
  baseURL: "http://localhost:7267/api", // Backend base URL
});

// Fetch list of movies from the backend
export const getMovies = async () => {
  const response = await api.get("/Movies/get");
  return response.data;
};

// Fetching single movie IDs
export const getMovieById = async (id) => {
  const response = await api.get(`/Movies/${id}`);
  return response.data;
};

// Add a movie ticket to the cart
export const addTicketToCart = async (movieId, quantity) => {
  await api.post("/cart/add", { movieId, quantity });
};

// Get all items from the cart
export const getCart = async () => {
  const response = await api.get("/Cart/getcart");
  return response.data;
};

// Remove a ticket from the cart
export const removeTicketFromCart = async (ticketId) => {
  await api.delete(`/cart/removeTicket/${ticketId}`); // Fix: added backticks to form a dynamic URL
};
