using UnityEngine;

namespace SameOldStory.UI.Buttons {
    
    public class DeactivateGameObjectButton : MonoBehaviour {

        [SerializeField] private GameObject objectToDeactivate;

        public void DeactivateObject() => objectToDeactivate?.SetActive(false);

    }
    
    
}