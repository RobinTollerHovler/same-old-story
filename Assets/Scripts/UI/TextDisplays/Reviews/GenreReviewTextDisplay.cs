using SameOldStory.Core.Movies;

namespace SameOldStory.UI.TextDisplays.Reviews {
    
    public class GenreReviewTextDisplay : ReviewTextDisplay {
        
        private void OnEnable() {
            Movie activeMovie = Movie.Active;
            if (activeMovie == null) return;
            SetReview(activeMovie.GenreReview.Get, "Genre reviewer");
        }
        
    }
    
}