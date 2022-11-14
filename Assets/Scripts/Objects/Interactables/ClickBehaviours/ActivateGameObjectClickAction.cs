using UnityEngine;

namespace SameOldStory.Objects.Interactables.ClickBehaviours {
    
    public class ActivateGameObjectClickAction : ClickAction {

        private readonly GameObject activateObject;
        
        public ActivateGameObjectClickAction(GameObject activateObject) {
            this.activateObject = activateObject;
        }

        public override void Click() {
            activateObject.SetActive(true);
        }
    }
    
}