using SameOldStory.UI.Buttons;

namespace SameOldStory.UI.Windows {

    public class BackButton : Button {
        
        private Window window;
        private delegate void ContextClickAction();
        private ContextClickAction contextClickAction;
        
        protected override void Click() {
            base.Click();
            if (window != null) window.ActiveContentSet = window.ActiveContentSet.Previous;
        }

        private void Start() {
            window = GetComponentInParent<Window>();
            if (window != null) window.onActiveContentSetChanged += SetButtonContextBehaviour;
            SetButtonContextBehaviour();
        }

        private void SetButtonContextBehaviour() {
            ContentSet contentSet = window.ActiveContentSet;
            if (contentSet?.Previous != null) {
                SetText("Back");
                gameObject.SetActive(true);
            } else {
                gameObject.SetActive(false);
            }
        }

    }

}