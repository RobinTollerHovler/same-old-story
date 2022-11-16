using SameOldStory.Core.Movies;
using SameOldStory.Core.Studios;

namespace SameOldStory.UI.Windows.Specifics {
    
    public class MovieMakerWindow : Window {

        private MovieNameInputField movieNameInputField;
        private MovieGenreDropdown movieGenreDropdown;
        
        private void Awake() {
            movieNameInputField = GetComponentInChildren<MovieNameInputField>();
            movieGenreDropdown = GetComponentInChildren<MovieGenreDropdown>();
        }

        public override void Submit() {
            Movie newMovie = new Movie(
                movieNameInputField?.Text,
                Studio.Current.GetGenreWithName(movieGenreDropdown.Selected())
            );
            newMovie.Activate();
            movieNameInputField?.Clear();
            Close();
        }
        
    }
    
}