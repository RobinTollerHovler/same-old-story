using SameOldStory.Movies;
using SameOldStory.Objects.Interactables.Posters.Components;

namespace SameOldStory.Objects.Interactables.Posters {
    
    public abstract class Poster : InteractableObject {

        private PosterMovieTitleText posterMovieTitleText;

        public void AssignMovie(Movie movie) {
            posterMovieTitleText?.Set(movie.Name);
        }

        private void Awake() => posterMovieTitleText = GetComponentInChildren<PosterMovieTitleText>();

    }
    
}