using SameOldStory.Movies;

namespace SameOldStory.Objects.Interactables.Posters {
    
    public class ActiveMoviePoster : Poster {

        private void Start() => SwapToMovie(null);

        private void OnEnable() => Movie.onActiveMovieChanged += SwapToMovie;
        private void OnDisable() => Movie.onActiveMovieChanged -= SwapToMovie;

        private void SwapToMovie(Movie movie) {
            AssignMovie(movie);
            TogglePoster(movie != null);
        }

        private void TogglePoster(bool value) {
            PosterNode?.Toggle(value);
        }
        
    }
    
}