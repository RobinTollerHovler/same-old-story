using System.Linq;
using SameOldStory.Core.Studios;
using SameOldStory.UI.Components;

namespace SameOldStory.UI.Windows.Specifics {
    
    public class PosterFontDropdown : DropdownComponent {
        
        private void OnEnable() {
            SetOptions(Studio.Current.AvailableFonts.Select(f => f.Name).ToArray());  
        }

    }
    
}