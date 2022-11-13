using SameOldStory.Movies;

namespace SameOldStory.Objects.ClickBehaviours {
    
    public class DiscardMovieClickBehaviour : ClickBehaviour {

        private readonly Movie discardMovie;
        
        public DiscardMovieClickBehaviour(Movie discardMovie) {
            this.discardMovie = discardMovie;
        }
        
        public override void Click() => discardMovie.Discard();

    }
    
}