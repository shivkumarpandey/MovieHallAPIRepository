using MovieHallAPI.Contracts;

namespace MovieHallAPI.Abstraction
{
    public interface IMovieHallProcessor
    {
         MovieHallAPIResponse GetAllMovies();

         Movie FindMovieByName(string name);
    }
}
