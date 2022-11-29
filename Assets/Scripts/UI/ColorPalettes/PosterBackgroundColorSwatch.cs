using Core.Movies;

namespace UI.ColorPalettes {
    
    public class PosterBackgroundColorSwatch : Swatch {
        
        protected override void Click() {
            base.Click();
            Script.CurrentlyWritingScript.PosterSettings.PosterBackgroundColor = Tone.Value;
        }
        
    }
    
}