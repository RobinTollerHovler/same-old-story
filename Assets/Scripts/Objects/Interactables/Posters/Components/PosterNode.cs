using UnityEngine;

namespace SameOldStory.Objects.Interactables.Posters.Components {
    
    public class PosterNode : MonoBehaviour {
        
        private float rotationFactor = 4f;
        
        private void Start() {
            transform.localEulerAngles = new Vector3(0, 0, Random.Range(-rotationFactor, rotationFactor));
        }
        
    }
    
}