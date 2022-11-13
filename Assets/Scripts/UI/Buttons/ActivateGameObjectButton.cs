using UnityEngine;

namespace SameOldStory.UI.Buttons {
    
    public class ActivateGameObjectButton : MonoBehaviour {
        
        [SerializeField] private GameObject objectToDeactivate;

        public void DeactivateObject() => objectToDeactivate?.SetActive(false);
        
    }
    
}