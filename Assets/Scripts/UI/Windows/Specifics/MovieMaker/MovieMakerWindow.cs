using System.Linq;
using Core.Movies;
using SameOldStory.Core.Movies;
using SameOldStory.Core.Studios;

namespace SameOldStory.UI.Windows.Specifics {
    
    public class MovieMakerWindow : Window {

        private MovieNameInputField movieNameInputField;
        private MovieGenreDropdown movieGenreDropdown;

        private RoleThumbnail[] roleThumbnails;

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
            roleThumbnails = GetComponentsInChildren<RoleThumbnail>();
            foreach(RoleThumbnail roleThumbnail in roleThumbnails) roleThumbnail.Hide();
            if(roleThumbnails.Length > 0) roleThumbnails[0].Show();
        }
        
        private void OnEnable() => Script.onRequestCreateNewScript += Open;
        private void OnDisable() => Script.onRequestCreateNewScript -= Open;
        
    }
    
}