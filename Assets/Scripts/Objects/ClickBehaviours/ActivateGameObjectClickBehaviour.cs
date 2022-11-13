using UnityEngine;

namespace SameOldStory.Objects.ClickBehaviours {
    
    public class ActivateGameObjectClickBehaviour : ClickBehaviour {

        private readonly GameObject activateObject;
        
        public ActivateGameObjectClickBehaviour(GameObject activateObject) {
            this.activateObject = activateObject;
        }

        public override void Click() {
            activateObject.SetActive(true);
        }
    }
    
}