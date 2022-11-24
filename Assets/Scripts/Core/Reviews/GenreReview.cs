using SameOldStory.Core.Movies;

namespace SameOldStory.Core.Reviews {
    
    public class GenreReview : Review {

        public GenreReview(Movie movie) : base(movie) {
            review = $"This was an {movie.Genre.Name}";
        }

    }
    
}