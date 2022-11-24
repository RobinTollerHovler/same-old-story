using SameOldStory.Core.Movies;

namespace SameOldStory.Core.Reviews {
    
    public abstract class Review {

        protected string review;

        protected Review(Movie movie) {}
        
        public string Get => review;

    }
    
}