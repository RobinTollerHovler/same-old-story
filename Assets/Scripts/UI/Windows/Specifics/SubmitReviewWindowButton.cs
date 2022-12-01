using SameOldStory.Core.Time;

namespace SameOldStory.UI.Windows.Specifics {
    
    public class SubmitReviewWindowButton : SubmitWindowButton {

        protected override void Click() {
            base.Click();
            Cycle.Resume();
        }
        
    }
    
}