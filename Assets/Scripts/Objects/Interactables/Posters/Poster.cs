using SameOldStory.Core.Movies;
using SameOldStory.Objects.Interactables.Posters.Components;

namespace SameOldStory.Objects.Interactables.Posters {
    
    public abstract class Poster : InteractableObject {

        protected Movie movie;
        private PosterMovieTitleText posterMovieTitleText;

        protected PosterNode PosterNode { get; private set; }
        
        public void AssignMovie(Movie movie) {
            if (movie == null) return;
            this.movie = movie;
            posterMovieTitleText?.Set(movie.Name);
        }

        protected virtual void Awake() {
            posterMovieTitleText = GetComponentInChildren<PosterMovieTitleText>();
            PosterNode = GetComponentInChildren<PosterNode>();
        }
        
    }
    
}