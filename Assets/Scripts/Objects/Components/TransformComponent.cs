using UnityEngine;

namespace SameOldStory.Objects.Components {
    
    public class TransformComponent : MonoBehaviour {

        public void SetLocalScale(Vector3 localScale) => transform.localScale = localScale;
        
    }
    
}