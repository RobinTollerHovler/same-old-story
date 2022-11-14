using SameOldStory.Input.Mouse;
using SameOldStory.Objects.Interactables.Posters.Components;
using UnityEngine;
using UnityEngine.Rendering;

namespace SameOldStory.Objects.Interactables.Posters {
    
    public class HangablePoster : Poster {
        
        private PosterColliderObject posterColliderObject;
        private SortingGroup sortingGroup;
        private bool placed;

        public void Sort(int count) {
            sortingGroup.sortingOrder = count * 5;
            GetComponentInChildren<Canvas>().sortingOrder = count * 5 + 1;
        }

        protected override void Awake() {
            base.Awake();
            posterColliderObject = GetComponentInChildren<PosterColliderObject>();
            sortingGroup = GetComponent<SortingGroup>();
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

        private void ActivateCollider() => posterColliderObject?.Activate();
        private void DeactivateCollider() => posterColliderObject?.Deactivate();

    }
    
}