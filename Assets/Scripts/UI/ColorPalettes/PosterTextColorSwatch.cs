using Core.Movies;

namespace UI.ColorPalettes {
    
    public class PosterTextColorSwatch : Swatch {
        
        protected override void Click() {
            base.Click();
            Script.CurrentlyWritingScript.PosterSettings.PosterTextColor = Tone.Value;
        }
        
    }
    
}