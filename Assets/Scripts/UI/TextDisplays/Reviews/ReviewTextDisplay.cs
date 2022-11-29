using SameOldStory.Core;
using SameOldStory.Core.Studios;
using UnityEngine;

namespace SameOldStory.UI.TextDisplays.Reviews {
    
    public class ReviewTextDisplay : TextDisplay {

        protected virtual void OnEnable() {
            IRepresentMovie representMovie = GetComponentInParent<IRepresentMovie>();
            if (representMovie != null) {
                SetText(
                    GeneratedReview(representMovie) +
                    GeneratedReview(representMovie) +
                    GeneratedReview(representMovie) +
                    GeneratedReview(representMovie) + (Application.isEditor ? $" --- SCORE {representMovie.Movie.Review.Score}" : "")
                );
            }
        }

        private string GeneratedReview(IRepresentMovie representMovie) {
            return $"\"{representMovie.Movie.Review.RandomReview}\" - {Studio.Current.RandomReviewer}\n\n";
        }
        
    }
    
}