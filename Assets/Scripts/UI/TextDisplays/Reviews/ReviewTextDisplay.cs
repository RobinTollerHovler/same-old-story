using SameOldStory.Core;
using SameOldStory.Core.Studios;

namespace SameOldStory.UI.TextDisplays.Reviews {
    
    public class ReviewTextDisplay : TextDisplay {

        protected virtual void OnEnable() {
            IRepresentMovie representMovie = GetComponentInParent<IRepresentMovie>();
            if (representMovie != null) {
                SetText(
                    GeneratedReview(representMovie) +
                    GeneratedReview(representMovie) +
                    GeneratedReview(representMovie) +
                    GeneratedReview(representMovie)
                );
            }
        }

        private string GeneratedReview(IRepresentMovie representMovie) {
            return $"\"{representMovie.Movie.Review.RandomReview}\" - {Studio.Current.RandomReviewer}\n\n";
        }
        
    }
    
}