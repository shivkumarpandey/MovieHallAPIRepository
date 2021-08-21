using MovieHallAPI.Contracts;

namespace MovieHallAPI.Abstraction
{
    public interface IMovieHallProcessor
    {
         MovieHallAPIResponse GetAllMovies();

         Movie FindMovieByName(MovieHallAPIRequest request);
    }
}
