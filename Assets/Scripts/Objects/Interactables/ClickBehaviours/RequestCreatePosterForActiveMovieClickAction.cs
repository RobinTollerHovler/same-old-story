using SameOldStory.Core.Movies;

namespace SameOldStory.Objects.Interactables.ClickBehaviours {
    
    public class RequestCreatePosterForActiveMovieClickAction : ClickAction {
        
        public override void Click() => Movie.CreatePoster();
        
    }
    
}