using Core.Movies;

namespace SameOldStory.UI.Windows.Specifics {
    
    public class CloseScriptCreatorButton : CloseWindowButton {
        
        protected override void Click() {
            Script.ClearScript();
            base.Click();
        }
        
    }
    
}