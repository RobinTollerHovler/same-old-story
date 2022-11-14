namespace SameOldStory.Objects.Interactables.ClickBehaviours {
    
    public class PlacePosterClickBehaviour : ClickBehaviour {
        
        public override void Click() {
            Movies.Poster.Place();
        }
        
    }
    
}