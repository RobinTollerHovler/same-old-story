using SameOldStory.Core.Movies;

namespace SameOldStory.Objects.Interactables.ClickBehaviours {
    
    public class RequestCreateNewMovieClickAction : ClickAction {
        
        public override void Click() => Movie.Create();

    }
    
}