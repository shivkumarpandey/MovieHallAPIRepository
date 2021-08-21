using Moq;
using MovieHallAPI.Abstraction;
using MovieHallAPI.Contracts;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace MovieHallAPI.Core.Test
{
    public class MovieHallFakeRepository : Mock<IMovieHallRepository>
    {
        public MovieHallFakeRepository GetAllMoviesMockResponse()
        {
            MovieHallAPIResponse response = new MovieHallAPIResponse()
            {
                ListOfMovies = new System.Collections.Generic.List<Movie>(),
                MessageId = new Guid().ToString(),
                ResponseDateTime = DateTime.Now
            };

            using (StreamReader r = new StreamReader("movies.json"))
            {
                string json = r.ReadToEnd();
                response.ListOfMovies = JsonConvert.DeserializeObject<List<Movie>>(json);
            }

            Setup(x => x.GetAllMoviesFromAPI()).Returns(response);

            return this;
        }

        public MovieHallFakeRepository FindMovieByName(string title)
        {
            MovieHallAPIResponse response = new MovieHallAPIResponse()
            {
                ListOfMovies = new System.Collections.Generic.List<Movie>(),
                MessageId = new Guid().ToString(),
                ResponseDateTime = DateTime.Now
            };

            using (StreamReader r = new StreamReader("movies.json"))
            {
                string json = r.ReadToEnd();
                response.ListOfMovies = JsonConvert.DeserializeObject<List<Movie>>(json);
            }
            Movie movie = response.ListOfMovies.Where(x => x.Title.Equals(title)).SingleOrDefault();
            Setup(x => x.FindMovieByName(It.IsAny<MovieHallAPIRequest>())).Returns(movie);
            return this;
        }
    }
}