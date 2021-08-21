using Microsoft.Extensions.Logging;
using MovieHallAPI.Abstraction;
using MovieHallAPI.Contracts;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace MovieHallAPI.Repository
{
    public class MovieHallRepository : IMovieHallRepository
    {
        ILogger _logger;
        public MovieHallRepository(ILogger<MovieHallRepository> logger)
        {
            _logger = logger;
        }

        public Movie FindMovieByName(string name)
        {
            MovieHallAPIResponse aPIResponse = new MovieHallAPIResponse()
            {
                ListOfMovies = LoadJson()
            };
           Movie movie = aPIResponse.ListOfMovies.Where(x => x.Title.Equals(name)).SingleOrDefault();

            return movie;
        }

        public MovieHallAPIResponse GetAllMoviesFromAPI()
        {
            MovieHallAPIResponse aPIResponse = new MovieHallAPIResponse()
            {
                ListOfMovies = LoadJson()
            };
            return aPIResponse;
        }

        public List<Movie> LoadJson()
        {
            List<Movie> items;
            using (StreamReader r = new StreamReader("movies.json"))
            {
                string json = r.ReadToEnd();
                items = JsonConvert.DeserializeObject<List<Movie>>(json);
            }

            return items;
        }
    }

}
