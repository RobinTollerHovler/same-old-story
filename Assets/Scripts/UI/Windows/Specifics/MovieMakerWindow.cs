using System.Linq;
using SameOldStory.Core.Movies;
using SameOldStory.Core.Studios;

namespace SameOldStory.UI.Windows.Specifics {
    
    public class MovieMakerWindow : Window {

        private MovieNameInputField movieNameInputField;
        private MovieGenreDropdown movieGenreDropdown;
        
        public override void Submit() {
            Movie newMovie = new Movie(
                movieNameInputField?.Text,
                Studio.Current.GetGenreWithName(movieGenreDropdown.Selected())
            );
            newMovie.Activate();
            movieNameInputField?.Clear();
            Close();
        }
        
        protected override void SetUp() {
            movieNameInputField = GetComponentsInChildren<MovieNameInputField>(true).FirstOrDefault();
            movieGenreDropdown = GetComponentsInChildren<MovieGenreDropdown>(true).FirstOrDefault();
        }

        private void OnEnable() => Movie.onRequestCreateNewMovie += Open;
        private void OnDisable() => Movie.onRequestCreateNewMovie -= Open;
        
    }
    
}