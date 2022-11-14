using SameOldStory.Movies;
using SameOldStory.Objects.Interactables.ClickBehaviours;
using UnityEngine;

namespace SameOldStory.Objects.Interactables.Posters {
    
    public class PosterWall : InteractableObject {

        [SerializeField] private GameObject frameObject;
        [SerializeField] private GameObject poster;

        private int NumberOfPosters => GetComponentsInChildren<Poster>().Length;

        private void Awake() => ClickAction = new PlacePosterClickAction();
        
        private void OnEnable() {
            Movies.Poster.onGeneratePosterForMovie += MakePoster;
            Movies.Poster.onBeginPlacePoster += ActivateWallColliderObject;
            Movies.Poster.onPlacePoster += DeactivateWallColliderObject;
        }

        private void OnDisable() {
            Movies.Poster.onGeneratePosterForMovie -= MakePoster;
            Movies.Poster.onBeginPlacePoster -= ActivateWallColliderObject;
            Movies.Poster.onPlacePoster -= DeactivateWallColliderObject;
        }

        private void ActivateWallColliderObject() => frameObject?.SetActive(true);
        private void DeactivateWallColliderObject() => frameObject?.SetActive(false);
        
        private void MakePoster(Movie movie) {
            GameObject newPoster = Instantiate(poster, Vector3.zero, Quaternion.identity, transform);
            Poster p = newPoster.GetComponent<Poster>();
            p.Sort(NumberOfPosters * 5);
            p.AssignMovie(movie);
        }

    }
    
}