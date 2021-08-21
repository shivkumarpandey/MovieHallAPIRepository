using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using MovieHallAPI.Abstraction;
using MovieHallAPI.Contracts;
using MovieHallAPI.Repository;
using System;
using Xunit;

namespace MovieHallAPI.Core.Test
{
    public class MovieHallProcessorTest
    {
        private  ILogger<MovieHallProcess> _logger;
        private  IMovieHallProcessor _movieHallProcessor;
        private  IServiceCollection _serviceCollection;
        private  IServiceProvider serviceProvider;
        

        public MovieHallProcessorTest()
        {
            _serviceCollection = new ServiceCollection().AddLogging()
                                     .AddTransient<IMovieHallProcessor, MovieHallProcess>()
                                     .AddTransient<IMovieHallRepository, MovieHallRepository>();
            serviceProvider = _serviceCollection.BuildServiceProvider();
            ILoggerFactory loggerFactory = serviceProvider.GetService<ILoggerFactory>();
            _logger = loggerFactory.CreateLogger<MovieHallProcess>();

        }

        [Fact]
        public void GetAllMovies()
        {
            MovieHallAPIRequest request = new MovieHallAPIRequest()
            {
                MessageId = Guid.NewGuid().ToString(),
                RequestDateTime = DateTime.Now
            };
            MovieHallFakeRepository movieHallFakeRepository = new MovieHallFakeRepository().GetAllMoviesMockResponse();
            IMovieHallRepository movieHallRepository = movieHallFakeRepository.Object;
            _serviceCollection.AddTransient(_ => movieHallRepository);
            _movieHallProcessor = serviceProvider.GetRequiredService<IMovieHallProcessor>();

            var response =  _movieHallProcessor.GetAllMovies();
            Assert.NotNull(response);
        }

        [Fact]
        public void FindMovie()
        {
            MovieHallFakeRepository movieHallFakeRepository = new MovieHallFakeRepository().FindMovieByName("Harry Potter and the Chamber of Secrets");
            IMovieHallRepository movieHallRepository = movieHallFakeRepository.Object;
            _serviceCollection.AddTransient(_ => movieHallRepository);
            _movieHallProcessor = serviceProvider.GetRequiredService<IMovieHallProcessor>();
   
            var response = _movieHallProcessor.FindMovieByName("Harry Potter and the Chamber of Secrets");
            Assert.Equal(response.ImdbID, "tt0295297");
        }

    }
}
