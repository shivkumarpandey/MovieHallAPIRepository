using MovieHallAPI.Contracts;

namespace MovieHallAPI.Abstraction
{
    public interface IMovieHallRepository
    {

        Movie FindMovieByName(MovieHallAPIRequest request);
        MovieHallAPIResponse GetAllMoviesFromAPI();

    }
}
