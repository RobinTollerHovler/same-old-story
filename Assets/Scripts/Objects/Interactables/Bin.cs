using SameOldStory.Core.Movies;
using SameOldStory.Objects.Interactables.ClickBehaviours;

namespace SameOldStory.Objects.Interactables {
    
    public class Bin : InteractableObject {
        
        private void OnEnable() => Movie.onActiveMovieChanged += AssignMovieToBin;
        private void OnDisable() => Movie.onActiveMovieChanged -= AssignMovieToBin;

        private void AssignMovieToBin(Movie movie) {
            if (movie == null) {
                ClickAction = new NoClickAction();
                Tooltip = "";
            } else {
                ClickAction = new DiscardMovieClickAction(movie);
                Tooltip = $"Discard: {movie.Title}";
            }
        }

    }
    
}