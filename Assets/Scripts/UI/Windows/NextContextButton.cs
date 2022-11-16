using SameOldStory.UI.Buttons;

namespace SameOldStory.UI.Windows {
    
    public class NextContextButton : Button {

        private Window window;
        private delegate void ContextClickAction();
        private ContextClickAction contextClickAction;
        
        protected override void Click() {
            base.Click();
            contextClickAction();
        }

        private void Start() {
            window = GetComponentInParent<Window>();
            if (window != null) window.onActiveContentSetChanged += SetButtonContextBehaviour;
            SetButtonContextBehaviour();
        }
        
        private void SetButtonContextBehaviour() {
            ContentSet contentSet = window.ActiveContentSet;
            if (contentSet.Next != null) {
                SetText("Next");
                contextClickAction = NextContentSet;
            } else {
                SetText("Confirm");
                contextClickAction = SubmitWindow;
            }
        }

        private void NextContentSet() {
            window.ActiveContentSet = window.ActiveContentSet.Next;
        }

        private void SubmitWindow() {
            window.Submit();
        }
        
    }
    
}