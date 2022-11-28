using System.Linq;
using SameOldStory.Core.Studios;
using SameOldStory.UI.Components;

namespace SameOldStory.UI.Windows.Specifics {
    
    public class ProductGenreDropdown : DropdownComponent {

        private void OnEnable() {
            SetOptions(Studio.Current.AvailableGenres.Select(g => g.Name).ToArray());
        }

    }
    
}