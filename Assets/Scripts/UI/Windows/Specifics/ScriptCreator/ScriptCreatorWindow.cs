using System.Linq;
using Core.Movies;
using SameOldStory.Core.Movies;
using SameOldStory.Core.Studios;

namespace SameOldStory.UI.Windows.Specifics {
    
    public class ScriptCreatorWindow : Window {

        private ProductTitleInputField productTitleInputField;
        private ProductGenreDropdown productGenreDropdown;

        private RoleThumbnail[] roleThumbnails;

        public override void Submit() {
            Movie newMovie = new Movie(
                productTitleInputField?.Text,
                Studio.Current.GetGenreWithName(productGenreDropdown.Selected())
            );
            newMovie.Activate();
            productTitleInputField?.Clear();
            Close();
        }
        
        protected override void SetUp() {
            productTitleInputField = GetComponentsInChildren<ProductTitleInputField>(true).FirstOrDefault();
            productGenreDropdown = GetComponentsInChildren<ProductGenreDropdown>(true).FirstOrDefault();
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