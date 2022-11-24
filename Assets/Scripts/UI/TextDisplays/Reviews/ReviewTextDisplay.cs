using UnityEngine.UI;

namespace SameOldStory.UI.TextDisplays.Reviews {
    
    public abstract class ReviewTextDisplay : TextDisplay {

        protected void SetReview(string review, string reviewer) {
            SetText($"\"{review}\" - {reviewer}");
        }
        
    }
    
}