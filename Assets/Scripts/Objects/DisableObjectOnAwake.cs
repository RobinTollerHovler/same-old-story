using UnityEngine;

namespace SameOldStory.Objects {
    
    public class DisableObjectOnAwake: MonoBehaviour {
        
        private void Awake() => gameObject.SetActive(false);
        
    }
    
}