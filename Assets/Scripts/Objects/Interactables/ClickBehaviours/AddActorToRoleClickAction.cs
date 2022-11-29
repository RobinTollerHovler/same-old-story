using Core.Movies;
using Core.People;

namespace SameOldStory.Objects.Interactables.ClickBehaviours {
    
    public class AddActorToRoleClickAction : ClickAction {

        private Actor actor;

        public AddActorToRoleClickAction(Actor actor) {
            this.actor = actor;
        }
        
        public override void Click() {
            if (Script.CurrentlyCreating != null && !actor.IsWorking) {
                Script.CurrentlyCreating.AddActorToUncastedRole(actor);
            }
        }
        
    }
    
}