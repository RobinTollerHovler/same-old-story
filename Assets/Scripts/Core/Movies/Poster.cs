using System;

namespace SameOldStory.Core.Movies {
    
    public static class Poster {

        public static event Action<Movie> onGeneratePosterForMovie;
        public static event Action onBeginPlacePoster;
        public static event Action onPlacePoster;
        
        public static void Generate(Movie posterForMovie) {
            onGeneratePosterForMovie?.Invoke(posterForMovie);
            onBeginPlacePoster?.Invoke();
        }

        public static void Place() {
            onPlacePoster?.Invoke();
        }
        
    }
    
}