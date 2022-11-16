using SameOldStory.Core.Movies;
using SameOldStory.Objects.Interactables.ClickBehaviours;

namespace SameOldStory.Objects.Interactables.Posters {
    
    public class ActiveMoviePoster : Poster {

        private void Start() => SwapToMovie(null);

        private void OnEnable() => Movie.onActiveMovieChanged += SwapToMovie;
        private void OnDisable() => Movie.onActiveMovieChanged -= SwapToMovie;

        private void SwapToMovie(Movie movie) {
            AssignMovie(movie);
            TogglePoster(movie != null);
            if (movie == null) {
                ClickAction = new NoClickAction();
            } else {
                Tooltip = $"Release: {movie.Name}";
                ClickAction = new ReleaseMovieClickAction(movie);
            }
        }

        private void TogglePoster(bool value) {
            PosterNode?.Toggle(value);
        }
        
    }
    
}