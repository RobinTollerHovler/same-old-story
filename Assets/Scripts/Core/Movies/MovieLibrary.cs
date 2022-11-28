using System.Collections.Generic;
using SameOldStory.Core.Movies;

namespace Core.Movies {
    
    public class MovieLibrary {

        private HashSet<Movie> movies;

        public MovieLibrary() {
            movies = new HashSet<Movie>();
        }

    }
    
}