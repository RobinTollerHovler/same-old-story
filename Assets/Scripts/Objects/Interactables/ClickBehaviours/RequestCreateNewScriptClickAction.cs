using Core.Movies;

namespace SameOldStory.Objects.Interactables.ClickBehaviours {
    
    public class RequestCreateNewScriptClickAction : ClickAction {
        
        public override void Click() => Script.Create();

    }
    
}