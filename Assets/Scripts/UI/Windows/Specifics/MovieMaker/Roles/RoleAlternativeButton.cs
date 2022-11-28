using Core.Roles;
using SameOldStory.Core.Studios;
using SameOldStory.UI.Buttons;
using UnityEngine;

namespace UI.Windows.Specifics.MovieMaker.Roles {
    
    public class RoleAlternativeButton : Button {

        private Role role;

        protected override void Click() {
            base.Click();
            GetComponentInChildren<ActorMenu>()?.Open();
        }
        
        private void OnEnable() {
            role = Studio.Current.AvailableRoles[Random.Range(0, Studio.Current.AvailableRoles.Length)];
            SetText(role.RoleTitle);
        }
        
    }
    
}