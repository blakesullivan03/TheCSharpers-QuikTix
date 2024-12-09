document.addEventListener("DOMContentLoaded", function() {
    const carouselContainer = document.getElementById('carousel');
    const movieListContainer = document.getElementById('movie-list');
    const sortByDropdown = document.getElementById('sort-by');
    let movieData = [];
    let originalMovieData = [];  // Store the original unsorted movie data
  
    // Fetch movies from the API
    async function fetchMovies(sortBy = '') {
      try {
        // Build the API URL based on the sort option
        const url = sortBy 
          ? `https://localhost:7267/api/Movies/get?sortBy=${sortBy}`
          : 'https://localhost:7267/api/Movies/get';
          
        const moviesResponse = await fetch(url);
        const imagesResponse = await fetch('https://localhost:7267/api/Movies/images');
        const movies = await moviesResponse.json();
        const images = await imagesResponse.json();
  
        movieData = movies.map((movie, index) => ({
          ...movie,
          imagePath: images[index], // Attach image URL to the movie object
        }));
  
        // Store the original unsorted data
        originalMovieData = [...movieData];
  
        renderCarousel();  // Only render the carousel once
        renderMovieList();  // Render the movie list initially
      } catch (error) {
        console.error('Error fetching movies:', error);
      }
    }
  
    // Render Carousel (only once)
    function renderCarousel() {
      // Only render the carousel if it's not already rendered
      if (carouselContainer.children.length === 0) {
        const carouselWrapper = document.createElement('div');
        carouselWrapper.classList.add('carousel');
        movieData.forEach(movie => {
          const item = document.createElement('img');
          item.src = movie.imagePath;
          item.alt = movie.title;
          item.classList.add('carousel-item');
          carouselWrapper.appendChild(item);
        });
  
        const clonedItems = carouselWrapper.cloneNode(true);
        carouselWrapper.appendChild(clonedItems);
        carouselContainer.appendChild(carouselWrapper);
      }
    }
  
    // Render Movie List
    function renderMovieList() {
      movieListContainer.innerHTML = ''; // Clear the existing list
      movieData.forEach(movie => {
        const movieItem = document.createElement('div');
        movieItem.classList.add('movie-item');
  
        const moviePoster = document.createElement('img');
        moviePoster.src = movie.imagePath;
        moviePoster.alt = movie.title;
  
        const movieInfo = document.createElement('div');
        movieInfo.innerHTML = `
          <h2>${movie.title}</h2>
          <h3>Genre: ${movie.genre}</h3>
          <p><strong>Description:</strong> ${movie.description}</p>
          <p><strong>Duration:</strong> ${movie.duration} minutes</p>
          <p><strong>Rating:</strong> ${movie.rating} / 10</p>
          <p><strong>Tickets Available:</strong> ${movie.ticketCount}</p>
        `;
  
        movieItem.appendChild(moviePoster);
        movieItem.appendChild(movieInfo);
        movieListContainer.appendChild(movieItem);
      });
    }
  
    // Event listener for sort change
    sortByDropdown.addEventListener('change', function() {
      const sortBy = this.value;
      if (sortBy === 'Original') {
        movieData = [...originalMovieData]; // Reset to original order
      } else {
        fetchMovies(sortBy);  // Fetch sorted data
      }
      renderMovieList();  // Re-render the movie list with new sorting
    });
  
    // Fetch the movie data when the page loads
    fetchMovies();
  });