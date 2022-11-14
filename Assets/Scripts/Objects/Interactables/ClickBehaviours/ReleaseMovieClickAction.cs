using SameOldStory.Movies;

namespace SameOldStory.Objects.Interactables.ClickBehaviours {
    
    public class ReleaseMovieClickAction : ClickAction {

        private readonly Movie movie;

        public ReleaseMovieClickAction(Movie movie) {
            this.movie = movie;
        }
        
        public override void Click() => movie.Release();

    }
    
}