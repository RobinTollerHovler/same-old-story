using UnityEngine;

namespace SameOldStory.Movies.Posters {
    
    public class PosterGraphic : MonoBehaviour {

        [SerializeField] private Transform node;
        private float rotationFactor = 4f;
        
        private void Start() {
            if (node == null) return;
            node.localEulerAngles = new Vector3(0, 0, Random.Range(-rotationFactor, rotationFactor));
        }
        
    }
    
}