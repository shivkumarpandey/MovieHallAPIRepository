using System;
using System.Collections.Generic;
using System.Text;

namespace MovieHallAPI.Contracts
{
    public class MovieHallAPIRequest :RequestBase
    {
        public Movie movie { get; set; }
    }
}
