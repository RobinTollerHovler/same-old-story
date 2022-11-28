using UI.Menus;
using UnityEngine;

namespace SameOldStory.UI.Buttons {
    
    public class OpenActorMenuButton : Button {
        
        [SerializeField] private ActorMenu actorMenu;
        
        protected override void Click() {
            base.Click();
            Debug.Log("ASD");
            roleMenu.Open();
        }
    }
    
}