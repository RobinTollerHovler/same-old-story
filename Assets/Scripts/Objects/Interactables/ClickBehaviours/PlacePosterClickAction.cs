namespace SameOldStory.Objects.Interactables.ClickBehaviours {
    
    public class PlacePosterClickAction : ClickAction {
        
        public override void Click() {
            Movies.Poster.Place();
        }
        
    }
    
}