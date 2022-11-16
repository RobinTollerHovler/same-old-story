using SameOldStory.Movies;

namespace SameOldStory.UI.Windows.Specifics {
    
    public class MovieMakerWindow : Window {

        private MovieNameInputField movieNameInputField;

        private void Awake() => movieNameInputField = GetComponentInChildren<MovieNameInputField>();
        
        public override void Submit() {
            Movie newMovie = new Movie(movieNameInputField?.Text);
            newMovie.Activate();
            movieNameInputField?.Clear();
            Close();
        }
        
    }
    
}