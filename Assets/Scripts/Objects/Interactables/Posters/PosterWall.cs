using SameOldStory.Core.Movies;
using SameOldStory.Objects.Interactables.ClickBehaviours;
using UnityEngine;

namespace SameOldStory.Objects.Interactables.Posters {
    
    public class PosterWall : InteractableObject {

        [SerializeField] private GameObject frameObject;
        [SerializeField] private GameObject hangablePosterTemplate;

        private int NumberOfPosters => GetComponentsInChildren<HangablePoster>().Length;

        private void Awake() => ClickAction = new PlacePosterClickAction();
        
        private void OnEnable() {
            Core.Movies.Poster.onGeneratePosterForMovie += MakePoster;
            Core.Movies.Poster.onBeginPlacePoster += ActivateWallColliderObject;
            Core.Movies.Poster.onPlacePoster += DeactivateWallColliderObject;
        }

        private void OnDisable() {
            Core.Movies.Poster.onGeneratePosterForMovie -= MakePoster;
            Core.Movies.Poster.onBeginPlacePoster -= ActivateWallColliderObject;
            Core.Movies.Poster.onPlacePoster -= DeactivateWallColliderObject;
        }

        private void ActivateWallColliderObject() => frameObject?.SetActive(true);
        private void DeactivateWallColliderObject() => frameObject?.SetActive(false);
        
        private void MakePoster(Movie movie) {
            GameObject newPoster = Instantiate(hangablePosterTemplate, Vector3.zero, Quaternion.identity, transform);
            HangablePoster hp = newPoster.GetComponent<HangablePoster>();
            hp.Sort(NumberOfPosters);
            hp.AssignProduct(movie);
            hp.AssignMovie(movie);
        }

    }
    
}