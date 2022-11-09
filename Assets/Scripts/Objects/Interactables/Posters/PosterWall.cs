using SameOldStory.Movies;
using UnityEngine;

namespace SameOldStory.Objects.Interactables {
    
    public class PosterWall : InteractableObject {

        [SerializeField] private GameObject frameObject;
        [SerializeField] private GameObject poster;

        public override void MouseClick() => Poster.Place();

        private void OnEnable() {
            Poster.onGeneratePosterForMovie += MakePoster;
            Poster.onBeginPlacePoster += ActivateWallColliderObject;
            Poster.onPlacePoster += DeactivateWallColliderObject;
        }

        private void OnDisable() {
            Poster.onGeneratePosterForMovie -= MakePoster;
            Poster.onBeginPlacePoster -= ActivateWallColliderObject;
            Poster.onPlacePoster -= DeactivateWallColliderObject;
        }

        private void ActivateWallColliderObject() => frameObject?.SetActive(true);
        private void DeactivateWallColliderObject() => frameObject?.SetActive(false);
        
        private void MakePoster(Movie movie) {
            Instantiate(poster);
        }

    }
    
}