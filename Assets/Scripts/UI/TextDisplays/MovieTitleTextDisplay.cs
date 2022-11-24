using SameOldStory.Core;

namespace SameOldStory.UI.TextDisplays {
    
    public class MovieTitleTextDisplay : TextDisplay {
        
        private void Start() {
            IRepresentMovie representMovie = GetComponentInParent<IRepresentMovie>();
            if(representMovie != null) SetText(representMovie.Movie.Name);
        }
        
    }
    
}