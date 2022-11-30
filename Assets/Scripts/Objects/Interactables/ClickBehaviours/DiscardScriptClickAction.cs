using Core.Movies;

namespace SameOldStory.Objects.Interactables.ClickBehaviours {
    
    public class DiscardScriptClickAction : ClickAction {

        public override void Click() => Script.ClearScript();

    }
    
}