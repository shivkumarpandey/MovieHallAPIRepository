using MovieHallAPI.Contracts;

namespace MovieHallAPI.Abstraction
{
    public interface IMovieHallRepository
    {

        Movie FindMovieByName(string name);
        MovieHallAPIResponse GetAllMoviesFromAPI();

    }
}
