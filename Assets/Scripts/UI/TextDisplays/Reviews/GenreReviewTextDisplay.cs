namespace SameOldStory.UI.TextDisplays.Reviews {
    
    public class GenreReviewTextDisplay : ReviewTextDisplay {
        
        protected override void OnEnable() {
            base.OnEnable();
            if (representMovie == null) return;
            SetReview(representMovie.Movie.GenreReview.Get, "Genre reviewer");
        }
        
    }
    
}