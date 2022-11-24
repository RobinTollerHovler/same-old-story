using SameOldStory.Core.Movies;

namespace SameOldStory.UI.Windows.Specifics {
    
    public class RatingWindow : Window {

        private void OpenWindowForMovie(Movie movie) {
            Open();
        }
        
        private void OnEnable() => Movie.onMovieReviewsCollected += OpenWindowForMovie;
        private void OnDisable() => Movie.onMovieReviewsCollected -= OpenWindowForMovie;
        
        public override void Submit() => Close();

    }
    
}