using System.Linq;
using SameOldStory.Core.Movies;
using SameOldStory.Core.Studios;

namespace SameOldStory.UI.Windows.Specifics {
    
    public class MovieMakerWindow : Window {

        private MovieNameInputField movieNameInputField;
        private MovieGenreDropdown movieGenreDropdown;

        private RoleButton[] roleButtons;

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

        protected override void OnOpen() {
            roleButtons = GetComponentsInChildren<RoleButton>();
            foreach(RoleButton roleButton in roleButtons) roleButton.Hide();
            if(roleButtons.Length > 0) roleButtons[0].Show();
        }
        
        private void OnEnable() => Movie.onRequestCreateNewMovie += Open;
        private void OnDisable() => Movie.onRequestCreateNewMovie -= Open;
        
    }
    
}