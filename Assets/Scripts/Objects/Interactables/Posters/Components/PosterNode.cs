using UnityEngine;

namespace SameOldStory.Objects.Interactables.Posters.Components {
    
    public class PosterNode : MonoBehaviour {
        
        private float rotationFactor = 4f;

        public void Toggle(bool value) => gameObject.SetActive(value);

        private void OnEnable() {
            transform.localEulerAngles = new Vector3(0, 0, Random.Range(-rotationFactor, rotationFactor));
        }

    }
    
}