using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieHallAPI.Contracts
{
    public class Movie
    {
        public string Title { get; set; }
        public string ImdbID { get; set; }

        public string ImdbRating { get; set; }

        public string listingType { get; set; }

        public List<string> Stills = new List<string>();

        public string Language { get; set; }

        public string Location { get; set; }

        public string Plot { get; set; }

        public string Poster { get; set; }

        public List<string> SoundEffects = new List<string>();
    }
}
