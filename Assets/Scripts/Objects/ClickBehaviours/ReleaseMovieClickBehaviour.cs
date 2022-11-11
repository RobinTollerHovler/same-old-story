using SameOldStory.Movies;

namespace SameOldStory.Objects {
    
    public class ReleaseMovieClickBehaviour : ClickBehaviour {

        private readonly Movie movie;

        public ReleaseMovieClickBehaviour(Movie movie) {
            this.movie = movie;
        }
        
        public override void Click() => movie.Release();

    }
    
}