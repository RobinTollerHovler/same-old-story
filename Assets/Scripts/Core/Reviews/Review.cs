using SameOldStory.Core.Movies;

namespace SameOldStory.Core.Reviews {
    
    public abstract class Review {
        
        protected string review;
        protected readonly Movie movie;

        protected Review(Movie movie) {
            this.movie = movie;
        }

        public float Score { get; protected set; }

        public string Get => review;

    }
    
}