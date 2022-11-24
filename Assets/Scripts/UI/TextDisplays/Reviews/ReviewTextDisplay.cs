using SameOldStory.Core;

namespace SameOldStory.UI.TextDisplays.Reviews {
    
    public abstract class ReviewTextDisplay : TextDisplay {

        protected IRepresentMovie representMovie;
        
        protected virtual void OnEnable() {
            representMovie = GetComponentInParent<IRepresentMovie>();
        }
        
        protected void SetReview(string review, string reviewer) {
            SetText($"\"{review}\" - {reviewer}");
        }
        
    }
    
}