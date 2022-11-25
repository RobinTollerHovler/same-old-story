using System.Linq;
using SameOldStory.Core.Reviews;
using UnityEngine;

namespace Core.Movies {
    
    public class Rating {

        private readonly float score;

        public Rating(params Review[] reviews) {
            int numberOfReviews = reviews.Length;
            float collectedScore = reviews.Sum(r => r.Score);
            score = collectedScore / numberOfReviews;
        }

        public int Stars() {
            return Mathf.RoundToInt(score / 2);
        }
        
    }
    
}