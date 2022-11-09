using SameOldStory.Movies;
using SameOldStory.Movies.Posters;

namespace SameOldStory.Objects {
    
    public class MakePosterClickBehaviour : ClickBehaviour {

        private readonly Movie posterForMovie;

        public MakePosterClickBehaviour(Movie posterForMovie) {
            this.posterForMovie = posterForMovie;
        }
        
        public override void Click() {
            Poster.Generate(posterForMovie);
        }
        
    }
    
}