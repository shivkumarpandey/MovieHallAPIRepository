using System;
using System.Collections.Generic;
using System.Text;

namespace MovieHallAPI.Contracts
{
    public class MovieHallAPIResponse : ResponseBase
    {
       public List<Movie> ListOfMovies = new List<Movie>();
    }
}
