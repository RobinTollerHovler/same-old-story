using SameOldStory.UI.Buttons;
using SameOldStory.UI.Menus;

namespace UI.Windows.Specifics.ScriptCreator.Roles {
    
    public class CloseClosestWindowButton : Button {
        
        protected override void Click() {
            base.Click();
            GetComponentInParent<IMenu>()?.Close();
        }
        
    }
    
}