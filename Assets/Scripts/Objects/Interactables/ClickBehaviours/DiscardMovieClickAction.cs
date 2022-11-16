using SameOldStory.Core.Movies;

namespace SameOldStory.Objects.Interactables.ClickBehaviours {
    
    public class DiscardMovieClickAction : ClickAction {

        private readonly Movie discardMovie;
        
        public DiscardMovieClickAction(Movie discardMovie) {
            this.discardMovie = discardMovie;
        }
        
        public override void Click() => discardMovie.Discard();

    }
    
}