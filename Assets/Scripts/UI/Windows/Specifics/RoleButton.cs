using SameOldStory.UI.Buttons;
using UnityEngine;

namespace SameOldStory.UI.Windows.Specifics {
    
    public class RoleButton : Button {

        private RoleButtonNode node;

        protected override void Click() {
            base.Click();
        }
        

        public void Hide() => node?.gameObject.SetActive(false);
        public void Show() => node?.gameObject.SetActive(true);

    }
    
}