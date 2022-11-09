using SameOldStory.Input.Mouse;
using UnityEngine;

namespace SameOldStory.Objects.Interactables.Posters {
    
    public class Poster : InteractableObject {

        [SerializeField] private Transform node;
        [SerializeField] private GameObject colliderObject;
        [SerializeField] private SpriteRenderer backgroundSpriteRenderer;
        [SerializeField] private Canvas textCanvas;
        
        private bool placed;
        private float rotationFactor = 4f;

        public void Sort(int baseLayer) {
            if(backgroundSpriteRenderer != null) backgroundSpriteRenderer.sortingOrder = baseLayer + 1;
            if(textCanvas != null) textCanvas.sortingOrder = baseLayer + 2;
        }
        
        private void Start() {
            if (node == null) return;
            node.localEulerAngles = new Vector3(0, 0, Random.Range(-rotationFactor, rotationFactor));
        }

        private void OnEnable() {
            Movies.Poster.onPlacePoster += SetPlacement;
            Movies.Poster.onBeginPlacePoster += DeactivateCollider;
        }

        private void OnDisable() {
            Movies.Poster.onPlacePoster -= SetPlacement;
            Movies.Poster.onBeginPlacePoster -= DeactivateCollider;
        }

        private void Update() {
            if (!placed) Place();
        }

        private void Place() {
            GameObject obj = Mouse.ObjectUnderCursor;
            if (obj.GetComponentInParent<PosterWall>()) {
                transform.position = new Vector3(
                    Mouse.ObjectUnderCursorHitPoint.x,
                    Mouse.ObjectUnderCursorHitPoint.y,
                    Mouse.ObjectUnderCursorHitPoint.z
                );
            }
        }
        
        private void SetPlacement() {
            ActivateCollider();
            placed = true;
        }

        private void DeactivateCollider() => colliderObject?.gameObject.SetActive(false);
        private void ActivateCollider() => colliderObject?.gameObject.SetActive(true);

    }
    
}