using SameOldStory.Core;
using SameOldStory.Core.Movies;

namespace SameOldStory.UI.Windows.Specifics {
    
    public class RatingWindow : Window, IRepresentMovie {

        private void OpenWindowForMovie(Movie movie) {
            Movie = movie;
            Open();
        }
        
        private void OnEnable() => Movie.onMovieReviewsCollected += OpenWindowForMovie;
        private void OnDisable() => Movie.onMovieReviewsCollected -= OpenWindowForMovie;
        
        public override void Submit() => Close();

        public Movie Movie { get; set; }
        
    }
    
}