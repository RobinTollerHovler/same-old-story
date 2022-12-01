using System.Linq;
using Core.Movies;
using SameOldStory.Core.Studios;
using SameOldStory.UI.Components;

namespace SameOldStory.UI.Windows.Specifics {
    
    public class ProductGenreDropdown : DropdownComponent {

        private void OnEnable() {
            SetOptions(Studio.Current.AvailableGenres.Select(g => g.Name).ToArray());
            Script.CurrentlyCreating.Genre = Studio.Current.GetGenreWithName(Selected());
        }

        protected override void OnValueChanged(int i) {
            base.OnValueChanged(i);
            Script.CurrentlyCreating.Genre = Studio.Current.GetGenreWithName(Selected());
        }
        
    }
    
}