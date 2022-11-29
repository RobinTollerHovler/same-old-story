using System.Linq;
using Core.Movies;
using SameOldStory.Core.Studios;
using SameOldStory.UI.Components;
using Font = SameOldStory.Core.Data.Font;

namespace SameOldStory.UI.Windows.Specifics {
    
    public class PosterFontDropdown : DropdownComponent {
        
        private void OnEnable() {
            SetOptions(Studio.Current.AvailableFonts.Select(f => f.Name).ToArray());
        }

        protected override void OnValueChanged(int i) {
            base.OnValueChanged(i);
            Font f = Studio.Current.GetFontWithName(Selected());
            Script.CurrentlyWritingScript.PosterSettings.PosterFont = f.FontAsset;
        }

    }
    
}