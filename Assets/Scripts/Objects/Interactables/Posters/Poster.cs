using SameOldStory.Input.Mouse;
using SameOldStory.Objects.Interactables;
using UnityEngine;

namespace SameOldStory.Movies.Posters {
    
    public class Poster : InteractableObject {

        [SerializeField] private Transform node;
        [SerializeField] private GameObject colliderObject;
        
        private bool placed;
        private float rotationFactor = 4f;
        
        private void Start() {
            if (node == null) return;
            node.localEulerAngles = new Vector3(0, 0, Random.Range(-rotationFactor, rotationFactor));
        }

        private void OnEnable() => Movies.Poster.onPlacePoster += SetPlacement;

        private void Update() {
            if (!placed) Place();
        }

        private void Place() {
            GameObject obj = Mouse.ObjectUnderCursor;
            if (obj.GetComponentInParent<PosterWall>()) {
                transform.position = new Vector3(
                    Mouse.ObjectUnderCursorHitPoint.x,
                    Mouse.ObjectUnderCursorHitPoint.y,
                    Mouse.ObjectUnderCursorHitPoint.z - 0.1f
                );
            }
        }
        
        private void SetPlacement() {
            Movies.Poster.onPlacePoster -= SetPlacement;
            colliderObject.gameObject.SetActive(true);
            placed = true;
        }
        
    }
    
}