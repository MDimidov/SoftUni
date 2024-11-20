function sortMovies(input) {
  let movies = [];

  input.forEach((command) => {
    if (command.includes("addMovie")) {
      const [_, name] = command.split("addMovie ");

      movies.push({
        name,
        director: null,
        date: null,
      });
    } else if (command.includes("directedBy")) {
      const [movieName, director] = command.split(" directedBy ");

      const movie = movies.find((m) => m.name === movieName);
      if (movie) {
        movie.director = director;
      }
    } else if (command.includes("onDate")) {
      const [movieName, onDate] = command.split(" onDate ");

      const movie = movies.find((d) => d.name === movieName);
      if (movie) {
        movie.date = onDate;
      }
    }
  });

  movies
    .filter((m) => m.direcor !== null && m.date !== null)
    .forEach((m) => console.log(JSON.stringify(m)));
}

// sortMovies([
//   "addMovie Fast and Furious",
//   "addMovie Godfather",
//   "Inception directedBy Christopher Nolan",
//   "Godfather directedBy Francis Ford Coppola",
//   "Godfather onDate 29.07.2018",
//   "Fast and Furious onDate 30.07.2018",
//   "Batman onDate 01.08.2018",
//   "Fast and Furious directedBy Rob Cohen",
// ]);

// -----------------Method 2--------------------

function sortMovies(input) {
  let movies = [];

  input.forEach((command) => {
    if (command.includes("addMovie")) {
      const [_, name] = command.split("addMovie ");

      movies.push({
        name
      });
    } else if (command.includes("directedBy")) {
      const [movieName, director] = command.split(" directedBy ");

      const movie = movies.find((m) => m.name === movieName);
      // const direc = movies.find((m) => m.director === null);
      if (movie) {
        movie.director = director;
      }
    } else if (command.includes("onDate")) {
      const [movieName, onDate] = command.split(" onDate ");
      
      const movie = movies.find((m) => m.name === movieName);
      // const dated = movies.find((m) => m.date === null);
      if (movie) {
        movie.date = onDate;
      }
    }
  });

  movies
    .filter((m) => m.hasOwnProperty('name') && m.hasOwnProperty('date') && m.hasOwnProperty('director'))
    .forEach((m) => console.log(JSON.stringify(m)));
}

sortMovies([
  "addMovie Fast and Furious",
  "addMovie Godfather",
  "Inception directedBy Christopher Nolan",
  "Godfather directedBy Francis Ford Coppola",
  "Godfather onDate 29.07.2018",
  "Fast and Furious onDate 30.07.2018",
  "Fast and Furious onDate 30.07.2024",
  "Batman onDate 01.08.2018",
  "Fast and Furious directedBy Rob Cohen",
  "Fast and Furious directedBy John Cohen",
]);
