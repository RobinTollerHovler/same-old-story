using SameOldStory.Movies;
using SameOldStory.Objects.Interactables.Posters.Components;
using UnityEngine;

namespace SameOldStory.Objects.Interactables.Posters {
    
    public abstract class Poster : InteractableObject {

        private PosterMovieTitleText posterMovieTitleText;

        protected PosterNode PosterNode { get; private set; }
        
        public void AssignMovie(Movie movie) {
            Debug.Log("Assigning");
            if (movie == null) return;
            posterMovieTitleText?.Set(movie.Name);
        }

        protected virtual void Awake() {
            Debug.Log("Awaking");
            posterMovieTitleText = GetComponentInChildren<PosterMovieTitleText>();
            PosterNode = GetComponentInChildren<PosterNode>();
        }
        
    }
    
}