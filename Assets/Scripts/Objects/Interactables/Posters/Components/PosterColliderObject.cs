using UnityEngine;

namespace SameOldStory.Objects.Interactables.Posters.Components {
    
    public class PosterColliderObject : MonoBehaviour {
        
        public void Deactivate() => gameObject.SetActive(false);
        public void Activate() => gameObject.SetActive(true);
        
    }
    
}