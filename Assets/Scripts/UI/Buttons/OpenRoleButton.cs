using UI.Menus;
using UnityEngine;

namespace SameOldStory.UI.Buttons {
    
    public class OpenRoleButton : Button {

        [SerializeField] private RoleMenu roleMenu;
        
        protected override void Click() {
            base.Click();
            Debug.Log("ASD");
            roleMenu.Open();
        }
        
    }
    
}