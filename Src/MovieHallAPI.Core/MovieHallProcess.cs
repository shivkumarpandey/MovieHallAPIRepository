using Microsoft.Extensions.Logging;
using MovieHallAPI.Abstraction;
using MovieHallAPI.Contracts;
using System;
using System.Linq;

namespace MovieHallAPI.Core
{
    public class MovieHallProcess : IMovieHallProcessor
    {
        ILogger _logger;
        IMovieHallRepository movieHallRepository;
        public MovieHallProcess(IMovieHallRepository repository , ILogger<MovieHallProcess> logger)
        {
            _logger = logger;
            movieHallRepository = repository;
        }

        public Movie FindMovieByName(MovieHallAPIRequest request)
        {
            Movie response = movieHallRepository.FindMovieByName(request);

            return response;
        }

        public MovieHallAPIResponse GetAllMovies()
        {
            MovieHallAPIResponse response = movieHallRepository.GetAllMoviesFromAPI();
            _logger.LogInformation("AddMovies in MovieHallProcess");
            return response;
        }
    }
}
