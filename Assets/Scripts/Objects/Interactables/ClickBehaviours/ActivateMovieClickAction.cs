using SameOldStory.Movies;

namespace SameOldStory.Objects.Interactables.ClickBehaviours {
    
    public class ActivateMovieClickAction : ClickAction {

        private readonly Movie movie;
        
        public ActivateMovieClickAction(Movie movie) => this.movie = movie;

        public override void Click() => movie.Activate();

    }
    
}