using SameOldStory.UI.Buttons;

namespace SameOldStory.UI.Windows {
    
    public class CloseWindowButton : Button {
        
        protected override void Click() {
            base.Click();
            GetComponentInParent<Window>()?.Close();
        }
        
    }
    
}