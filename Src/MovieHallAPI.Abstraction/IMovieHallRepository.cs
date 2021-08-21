using MovieHallAPI.Contracts;

namespace MovieHallAPI.Abstraction
{
    public interface IMovieHallRepository
    {

        MovieHallAPIResponse FindMovieByName(MovieHallAPIRequest request);
        MovieHallAPIResponse GetAllMoviesFromAPI();

    }
}
