using SameOldStory.Core.Movies;

namespace SameOldStory.UI.Windows.Specifics {
    
    public class PosterWindow : Window {
        
        public override void Submit() {
            Movie.Active.StartProduction();
            Close();
        }

        private void OpenWindowForMovie(Movie movie) {
            Open();
        }
        
        private void OnEnable() => Movie.onRequestCreateMoviePoster += OpenWindowForMovie;
        private void OnDisable() => Movie.onRequestCreateMoviePoster -= OpenWindowForMovie;
        
    }
    
}