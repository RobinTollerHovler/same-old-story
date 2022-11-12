using UnityEngine;

namespace SameOldStory.Objects.Interactables.Scripts {
    
    public class Script : InteractableObject {

        public void SetXPosition(float position) {
            Debug.Log("Setting X: " + position);
            transform.localPosition = new Vector3(position, transform.localPosition.y, transform.localPosition.z);
        }
        
    }
    
}