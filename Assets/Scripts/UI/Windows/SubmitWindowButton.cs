using SameOldStory.UI.Buttons;

namespace SameOldStory.UI.Windows {
    
    public class SubmitWindowButton : Button {

        private Window window;

        protected override void Click() {
            base.Click();
            SubmitWindow();
        }

        protected override void SetUp() => window = GetComponentInParent<Window>();

        private void SubmitWindow() => window?.Submit();

    }
    
}