using System;

namespace SameOldStory.Movies.Posters {
    
    public static class Poster {

        public static event Action<Movie> onGeneratePosterForMovie;
        
        public static void Generate(Movie posterForMovie) => onGeneratePosterForMovie?.Invoke(posterForMovie);

    }
    
}