using UI.Menus;
using UnityEngine;

namespace SameOldStory.UI.Buttons {
    
    public class AddRoleButton : Button {

        [SerializeField] private RoleMenu roleMenu;
        
        protected override void Click() {
            base.Click();
            roleMenu.Open();
        }
        
    }
    
}