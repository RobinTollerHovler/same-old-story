using SameOldStory.Input.Mouse;
using UnityEngine;

namespace SameOldStory.Objects {
    
    public class ActivateGameObjectOnClick : MonoBehaviour, IReactToMouseClick {

        [SerializeField] private GameObject objectToActivate;

        public void MouseClick() => objectToActivate?.SetActive(true);
        
    }
    
}