using Core.Movies;
using SameOldStory.Core.Movies;

namespace SameOldStory.Objects.Interactables.ClickBehaviours {
    
    public class RequestCreatePosterForCurrentScriptClickAction : ClickAction {

        public override void Click() => Script.CreatePoster();
        
    }
    
}