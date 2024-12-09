export const getMovies = async () => {
    const response = await fetch('http://localhost:7267/api/Movies/get');
    const data = await response.json();
    return data;
  };
  
  export const getMovieById = async (id) => {
    const response = await fetch(`http://localhost:7267/api/Movies/get/${id}`);
    const data = await response.json();
    return data;
  };
  