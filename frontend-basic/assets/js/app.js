// Sample data from the API (replace with real API data in production)
const movies = [
  {
      id: 1,
      title: "All Quiet On the Western Front",
      imagePath: "assets/images/all-quiet-on-the-western-front.jpg"
  },
  {
      id: 2,
      title: "Inception",
      imagePath: "assets/images/inception.jpg"
  },
  {
      id: 3,
      title: "Interstellar",
      imagePath: "assets/images/interstellar.jpg"
  },
  {
      id: 4,
      title: "The Matrix",
      imagePath: "assets/images/the-matrix.jpg"
  },
  {
      id: 5,
      title: "The Shawshank Redemption",
      imagePath: "assets/images/the-shawshank-redemption.jpg"
  }
];

// Function to render the carousel
function renderCarousel() {
  const carouselContainer = document.getElementById("carousel");
  movies.forEach(movie => {
      const img = document.createElement("img");
      img.src = movie.imagePath;
      img.alt = movie.title;
      img.title = movie.title;
      carouselContainer.appendChild(img);
  });
}

// Function to render the movie list
function renderMovies() {
  const movieContainer = document.getElementById("movies-container");
  movies.forEach(movie => {
      const movieCard = document.createElement("div");
      movieCard.classList.add("movie-card");

      const img = document.createElement("img");
      img.src = movie.imagePath;
      movieCard.appendChild(img);

      const movieInfo = document.createElement("div");
      movieInfo.classList.add("movie-info");
      movieInfo.innerHTML = `<h3>${movie.title}</h3><button onclick="addToCart(${movie.id})">Add to Cart</button>`;

      movieCard.appendChild(movieInfo);
      movieContainer.appendChild(movieCard);
  });
}

// Function to add a movie to the cart (stored in localStorage)
function addToCart(movieId) {
  let cart = JSON.parse(localStorage.getItem("cart")) || [];
  if (!cart.includes(movieId)) {
      cart.push(movieId);
      localStorage.setItem("cart", JSON.stringify(cart));
      updateCartButton();
  }
}

// Function to update the cart button (shows the number of items in the cart)
function updateCartButton() {
  const cart = JSON.parse(localStorage.getItem("cart")) || [];
  const cartBtn = document.querySelector(".cart-btn a");
  cartBtn.textContent = `Cart (${cart.length})`;
}

// Call the render functions
renderCarousel();
renderMovies();
updateCartButton();
